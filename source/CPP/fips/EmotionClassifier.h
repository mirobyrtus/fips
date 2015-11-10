#include <stdio.h>
#include <opencv2/opencv.hpp>
#include <sys/stat.h>

using namespace cv;

class EmotionClassifier
{
public:

	void setupClasses() {
		
		CLASSES[0] = "NEUTRAL";
		CLASSES[1] = "HAPPY";
		CLASSES[2] = "SAD";
		CLASSES[3] = "FEAR";
		// CLASSES[4] = "ANGER";
		// CLASSES[5] = "SURPRISE";
		// CLASSES[6] = "DISGUST";
	}

	void setupSVM() {
		params.svm_type = CvSVM::C_SVC;
		params.kernel_type = CvSVM::LINEAR;
		params.term_crit = cvTermCriteria(CV_TERMCRIT_ITER, 100, 1e-6);
	}

	EmotionClassifier() {
		setupClasses();
		setupSVM();
		loadSVM();
	}

	void addExpression(float label, Mat shape) {
		labelsMat.push_back(label);

		Mat shapeSVM = prepareShapeForSVM(shape);
		exprMat.push_back(shapeSVM);
	}

	void trainExpressionClassifier() {
		SVM.clear();
		SVM.train(exprMat, labelsMat, Mat(), Mat(), params);
		saveSVM();
	}

	float classifyExpression(Mat shape) {
		Mat shapeSVM = prepareShapeForSVM(shape);
		return SVM.predict(shapeSVM);
	}

	string getLabelDescription(float label) {
		return labelToClass(label);
	}

	void loadSVM() {
		// Check if trained SVM File exists
		struct stat statbuffer;
		if (stat(SVM_FILE_PATH, &statbuffer) == 0) {
			SVM.load(SVM_FILE_PATH);
			trained = true;
		}
	}

	void saveSVM() {
		SVM.save(SVM_FILE_PATH);
		trained = true;
	}

	bool trained = false;
	bool isTrained() { return trained; }

	const float NEUTRAL_CLASS = 0.0;
	const float HAPPY_CLASS = 1.0;
	const float SAD_CLASS = 2.0;
	const float FEAR_CLASS = 3.0;
	const float ANGER_CLASS = 4.0;
	const float SURPRISE_CLASS = 5.0;
	const float DISGUST_CLASS = 6.0;

private:

	Mat prepareShapeForSVM(Mat shape) {
		Mat shape_onerow = shape.reshape(1, 1);
		shape_onerow.convertTo(shape_onerow, CV_32FC1);

		// NORMALIZE ?
		bool normalize = false; // TODO Test
		if (normalize) {
			// Manual normalization
			float minimumX = -1;
			float minimumY = -1;

			int n = shape_onerow.cols / 2;
			for (int i = 0; i < n; i++){
				float x = shape_onerow.at<float>(0, i);
				if (minimumX == -1 || x < minimumX) {
					minimumX = x;
				}

				float y = shape_onerow.at<float>(0, i + n);
				if (minimumY == -1 || y < minimumY) {
					minimumY = y;
				}
			}
			for (int i = 0; i < n; i++){
				if (i < 17) {
					// IGNORE FIRST 17 POINTS - CHIN
					// TODO rather change Mat shape than set those values to 0
					shape_onerow.at<float>(0, i) = 0;
					shape_onerow.at<float>(0, i + n) = 0;
				}
				else {
					float x = shape_onerow.at<float>(0, i);
					shape_onerow.at<float>(0, i) = x - minimumX;

					float y = shape_onerow.at<float>(0, i + n);
					shape_onerow.at<float>(0, i + n) = y - minimumY;
				}
			}
		}
		return shape_onerow;
	}

	CvSVMParams params;
	CvSVM SVM;

	Mat labelsMat;
	Mat exprMat;

	const char* SVM_FILE_PATH = "trained_svm.yml";

	string labelToClass(float label) {
		int index = (int)label;
		return CLASSES[index];
	}

	// string CLASSES[7];
	string CLASSES[4];
};
