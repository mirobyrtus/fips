#include <stdio.h>
#include <opencv2/opencv.hpp>
#include <math.h>

using namespace cv;

class Stabilisator
{
public:

	static void stabiliseModel(Mat &shape) {
		int n = shape.rows / 2;

		int nose_center_id = 29;
		Point2d nose_center = Point2d(shape.at<double>(nose_center_id, 0), shape.at<double>(nose_center_id + n, 0));
		int left_part_id = 1;
		Point2d left = Point2d(shape.at<double>(left_part_id, 0), shape.at<double>(left_part_id + n, 0));
		int right_part_id = 15;
		Point2d right = Point2d(shape.at<double>(right_part_id, 0), shape.at<double>(right_part_id + n, 0));

		bool rotate = true;
		if (rotate) {
			float angle = 0.0f;

			// Calculate the Model Rotation
			float deltaY = right.y - left.y;
			float deltaX = right.x - left.x;
			float angleInDegrees = atan(deltaY / deltaX) * 180 / (atan(1) * 4);

			// Rotate back
			for (int i = 0; i < n; i++) {
				// if (shape.at<int>(i, 0) == 0)
				// continue;
				Point2d p = Point2d(shape.at<double>(i, 0), shape.at<double>(i + n, 0));
				p = rotate_point(nose_center.x, nose_center.y, - (angleInDegrees / (180 / (atan(1) * 4))), p);
				shape.at<double>(i, 0) = p.x;
				shape.at<double>(i + n, 0) = p.y;
			}
		}

		// Neutralize
		double minx = -1;
		double miny = -1;

		for (int i = 0; i < n; i++) {
			// if (shape.at<int>(i, 0) == 0)
			// continue;
			int x = shape.at<double>(i, 0);
			int y = shape.at<double>(i + n, 0);
			if (minx == -1 || x < minx) {
				minx = x;
			}
			if (miny == -1 || y < miny) {
				miny = y;
			}
		}
		for (int i = 0; i < n; i++) {
			// if (shape.at<int>(i, 0) == 0)
			// continue;
			shape.at<double>(i, 0) = shape.at<double>(i, 0) - minx;
			shape.at<double>(i + n, 0) = shape.at<double>(i + n, 0) - miny;
		}
	}

private:

	float calculateModelRotation() {
		return -1.0f;
	}

	static float find_angle(Point2d p0, Point2d p1, Point2d c) {
		float p0c = sqrt(pow(c.x - p0.x, 2) + pow(c.y - p0.y, 2)); // p0->c (b)   
		float p1c = sqrt(pow(c.x - p1.x, 2) + pow(c.y - p1.y, 2)); // p1->c (a)
		float p0p1 = sqrt(pow(p1.x - p0.x, 2) + pow(p1.y - p0.y, 2)); // p0->p1 (c)
		return acos((p1c*p1c + p0c*p0c - p0p1*p0p1) / (2 * p1c*p0c));
	}

	static Point2d rotate_point(float cx, float cy, float angle, Point2d p)
	{
		float s = sin(angle);
		float c = cos(angle);

		// translate point back to origin:
		p.x -= cx;
		p.y -= cy;

		// rotate point
		float xnew = p.x * c - p.y * s;
		float ynew = p.x * s + p.y * c;

		// translate point back:
		p.x = xnew + cx;
		p.y = ynew + cy;
		return p;
	}
};