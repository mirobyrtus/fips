#define EXPORT_API __declspec(dllexport) // Visual Studio needs annotating exported functions with this

#include <FaceTracker/Tracker.h>
#include <opencv/highgui.h>
#include <iostream>
#include "EmotionClassifier.h"
#include "Stabilisator.h"

void my_Draw(cv::Mat &image, cv::Mat &shape, cv::Mat &visi)
{
	int i, n = shape.rows / 2; 
	cv::Point p1;
	cv::Scalar c = CV_RGB(255, 0, 0);

	for (i = 0; i < n; i++){
		if (visi.at<int>(i, 0) == 0)
			continue;
		
		p1 = cv::Point(
			shape.at<double>(i, 0), 
			shape.at<double>(i + n, 0)
		);
		
		cv::putText(image, std::to_string(i), p1, 1, 1, cv::Scalar(255, 255, 255));
		// cv::circle(image, p1, 2, c);
	}
	return;
}

extern "C"
{
	FACETRACKER::Tracker model("../model/face2.tracker");
	bool fcheck = false; double scale = 1; int fpd = -1; bool show = true;
	// cv::Mat tri = FACETRACKER::IO::LoadTri("../model/face.tri"); // Triangulation
	// cv::Mat con = FACETRACKER::IO::LoadCon("../model/face.con"); // Connections
	//set other tracking parameters
	std::vector<int> wSize1(1);
	std::vector<int> wSize2(3);
	int nIter = 5; 
	double clamp = 3, fTol = 0.01;
	// Runtime vars
	cv::Mat frame, gray, im;
	double fps = 0;
	CvCapture* camera;
	// Runtime vars
	bool failed = true;
	// Emotion Classifier
	EmotionClassifier *emotionClassifier;
	// End Emotion Classifier
	// Model Stabilisation
	Stabilisator *modelStabilisator;
	// End Model Stabilisation

	void trackFace()
	{
		//grab image, resize and flip
		IplImage* I = cvQueryFrame(camera);
		if (!I) return;

		frame = I;
		if (scale == 1)im = frame;
		else cv::resize(frame, im, cv::Size(scale*frame.cols, scale*frame.rows));
		cv::flip(im, im, 1); cv::cvtColor(im, gray, CV_BGR2GRAY);

		//track this image
		std::vector<int> wSize;
		if (failed)
			wSize = wSize2;
		else
			wSize = wSize1;

		if (model.Track(gray, wSize, fpd, nIter, clamp, fTol, fcheck) == 0){
			failed = false;
		}
		else{
			if (show){ cv::Mat R(im, cvRect(0, 0, 150, 50)); R = cv::Scalar(0, 0, 255); }
			model.FrameReset();
			failed = true;
		}
	}

	EXPORT_API int getShape(float** pointsX, float** pointsY, int* classified_label, bool showCamera)
	{
		trackFace();
		
		// Uncomment if you want to stabilise the model
		// modelStabilisator->stabiliseModel(model._shape);

		if (showCamera) { // JUST TESTING
			int idx = model._clm.GetViewIdx();
			my_Draw(im, model._shape, model._clm._visi[idx]);
			imshow("Face Tracker", im);
		}
		
		if (failed) {
			return -1;
		}
		
		cv::Mat visi = model._clm._visi[model._clm.GetViewIdx()];
		
		int size = model._shape.rows / 2;
		float* tmpPointsX = new float[size];
		float* tmpPointsY = new float[size];

		for (int i = 0; i < size; i++) 
		{
			if (visi.at<int>(i, 0) == 0)
				continue;

			tmpPointsX[i] = model._shape.at<double>(i, 0);
			tmpPointsY[i] = model._shape.at<double>(i + size, 0);
		}

		*pointsX = tmpPointsX;
		*pointsY = tmpPointsY;

		int label = emotionClassifier->classifyExpression(model._shape);
		*classified_label = label;

		return size;
	}

	EXPORT_API bool initFaceTracker()
	{
		emotionClassifier = new EmotionClassifier();
		modelStabilisator = new Stabilisator();
		
		// cvNamedWindow("Face Tracker", 1); // JUST TESTING

		wSize1[0] = 7;
		wSize2[0] = 11; wSize2[1] = 9; wSize2[2] = 7;

		camera = cvCreateCameraCapture(CV_CAP_ANY);
		if (!camera) {
			return false;
		}

		return true;
	}

	EXPORT_API bool releaseFaceTracker()
	{
		cvReleaseCapture(&camera);
		cvDestroyWindow("Face Tracker");
		return true;
	}

	EXPORT_API bool reDetect()
	{
		model.FrameReset();
		return true;
	}

	int main(int argc, const char** argv)
	{
		initFaceTracker();
		
		int64 t1, t0 = cvGetTickCount(); int fnum = 0;

		cvNamedWindow("Face Tracker", 1);

		while (1){
			trackFace();

			if (!failed)
			{
				int idx = model._clm.GetViewIdx();
				// Uncomment when you want to stabilise the model
				// modelStabilisator->stabiliseModel(model._shape);
				my_Draw(im, model._shape, model._clm._visi[idx]);
			}

			//draw framerate on display image 
			if (fnum >= 9){
				t1 = cvGetTickCount();
				fps = 10.0 / ((double(t1 - t0) / cvGetTickFrequency()) / 1e+6);
				t0 = t1; fnum = 0;
			}
			else fnum += 1;

			//show image and check for user input
			imshow("Face Tracker", im);

			int c = cvWaitKey(10);
			if (c == 27) {
				break;
			}

			// TODO Happy Sad Fear Anger Surprise Disgust

			else if (char(c) == 'n') { // neutral
				emotionClassifier->addExpression(emotionClassifier->NEUTRAL_CLASS, model._shape);
			}
			else if (char(c) == 'h') { // happy
				emotionClassifier->addExpression(emotionClassifier->HAPPY_CLASS, model._shape);
			}
			else if (char(c) == 's') { // sad
				emotionClassifier->addExpression(emotionClassifier->SAD_CLASS, model._shape);
			}
			else if (char(c) == 'f') { // fear
				emotionClassifier->addExpression(emotionClassifier->FEAR_CLASS, model._shape);
			}
			else if (char(c) == 'a') { // anger
				emotionClassifier->addExpression(emotionClassifier->ANGER_CLASS, model._shape);
			}
			else if (char(c) == 'u') { // surprise
				emotionClassifier->addExpression(emotionClassifier->SURPRISE_CLASS, model._shape);
			}
			else if (char(c) == 'g') { // disgust
				emotionClassifier->addExpression(emotionClassifier->DISGUST_CLASS, model._shape);
			}
			else if (char(c) == 't') { // train
				emotionClassifier->trainExpressionClassifier();
			}
			else if (char(c) == 'c') { // classify
				std::cout << emotionClassifier->getLabelDescription(
					emotionClassifier->classifyExpression(model._shape)
				) << std::endl;
			}
			else if (char(c) == 'd') {
				model.FrameReset();
			}
		}
		return 0;
	}
}
//=============================================================================
