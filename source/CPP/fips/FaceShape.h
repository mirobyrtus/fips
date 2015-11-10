#include <stdio.h>
#include <opencv2/opencv.hpp>

using namespace cv;

/// --------------------
/// MOVED TO UNITY PART
/// --------------------

class FaceShape
{
public:

	FaceShape()
	{
		// initFromShape(shape);
	}

	void initFromShape(Mat shape) {
		// CHIN
		chin.clear();
		for (int i = 0; i < chin_size; i++) {
			chin.push_back(getPointAt(shape, chin_start + i));
		}

		// EYEBROW LEFT
		eyebrow_left.clear();
		for (int i = 0; i < eyebrow_size; i++) {
			eyebrow_left.push_back(getPointAt(shape, eyebrow_start_left + i));
		}

		// EYEBROW RIGHT
		eyebrow_right.clear();
		for (int i = 0; i < eyebrow_size; i++) {
			eyebrow_right.push_back(getPointAt(shape, eyebrow_start_right + i));
		}

		// NOSE
		nose.clear();
		for (int i = 0; i < nose_size; i++) {
			nose.push_back(getPointAt(shape, nose_start + i));
		}

		// NOSE BOTTOM
		nose_bottom.clear();
		for (int i = 0; i < nose_bottom_size; i++) {
			nose_bottom.push_back(getPointAt(shape, nose_bottom_start + i));
		}

		// EYE LEFT
		eye_left.clear();
		for (int i = 0; i < eye_size; i++) {
			eye_left.push_back(getPointAt(shape, eye_start_left + i));
		}

		// EYE RIGHT
		eye_right.clear();
		for (int i = 0; i < eye_size; i++) {
			eye_right.push_back(getPointAt(shape, eye_start_right + i));
		}

		// MOUTH OUTER
		mouth_outer.clear();
		for (int i = 0; i < mouth_size_outer; i++) {
			mouth_outer.push_back(getPointAt(shape, mouth_start_outer + i));
		}

		// MOUTH INNER
		mouth_inner.clear();
		for (int i = 0; i < mouth_size_inner; i++) {
			mouth_inner.push_back(getPointAt(shape, mouth_start_inner + i));
		}

	}

	~FaceShape() { }

	const int points_count = 66;

	const int chin_size = 17;
	const int chin_start = 0;
	vector<Point> chin;

	const int eyebrow_size = 5;
	const int eyebrow_start_left = chin_start + chin_size;
	const int eyebrow_start_right = eyebrow_start_left + eyebrow_size;
	vector<Point> eyebrow_left;
	vector<Point> eyebrow_right;

	const int nose_size = 4;
	const int nose_start = eyebrow_start_right + eyebrow_size;
	vector<Point> nose;

	const int nose_bottom_size = 5;
	const int nose_bottom_start = nose_start + nose_size;
	vector<Point> nose_bottom;

	const int eye_size = 6;
	const int eye_start_left = nose_bottom_start + nose_bottom_size;
	const int eye_start_right = eye_start_left + eye_size;
	vector<Point> eye_left;
	vector<Point> eye_right;

	const int mouth_size_outer = 12;
	const int mouth_start_outer = eye_start_right + eye_size;
	const int mouth_size_inner = 6;
	const int mouth_start_inner = mouth_size_outer + mouth_start_outer;
	vector<Point> mouth_outer;
	vector<Point> mouth_inner;

private:

	Point getPointAt(Mat shape, int index) {
		return Point(
			shape.at<float>(0, index),
			shape.at<float>(0, (shape.cols / 2) + index)
			);
	}

};
