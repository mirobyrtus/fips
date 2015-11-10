PROJECT(FTRACKER)

cmake_minimum_required(VERSION 2.8)
find_package(OpenCV REQUIRED)

INCLUDE_DIRECTORIES( ${CMAKE_BINARY_DIR} )
INCLUDE_DIRECTORIES( ${OpenCV_INCLUDE_DIR} )
INCLUDE_DIRECTORIES( "${OpenCV_DIR}/include" )

message(STATUS "OPENCV = ${OpenCV_DIR}/include")

INCLUDE_DIRECTORIES( "${CMAKE_SOURCE_DIR}/include" )

# SET( FACE_TRACKER_HDRS
#  ${CMAKE_SOURCE_DIR}/include/FaceTracker/CLM.h
#  ${CMAKE_SOURCE_DIR}/include/FaceTracker/FCheck.h
#  ${CMAKE_SOURCE_DIR}/include/FaceTracker/FDet.h
#  ${CMAKE_SOURCE_DIR}/include/FaceTracker/IO.h
#  ${CMAKE_SOURCE_DIR}/include/FaceTracker/Patch.h
#  ${CMAKE_SOURCE_DIR}/include/FaceTracker/PAW.h
#  ${CMAKE_SOURCE_DIR}/include/FaceTracker/PDM.h
#  ${CMAKE_SOURCE_DIR}/include/FaceTracker/Tracker.h
#)

SET(BIN_INSTALL_DIR
    "${CMAKE_SOURCE_DIR}/bin"
    CACHE PATH "The subdirectory relative to the install prefix for executables (default is bin)"
   )

SET(DATA_INSTALL_DIR
    "${CMAKE_SOURCE_DIR}/share"
    CACHE PATH "The subdirectory relative to the install prefix where shared data will be installed (default is share)."
   )

SET(FACE_TRACKER_BINARY_DIR
    "${CMAKE_SOURCE_DIR}/bin"
   )

SET( BINDIR "${FACE_TRACKER_BINARY_DIR}/${BIN_INSTALL_DIR}" )


SET( EXECUTABLE_OUTPUT_PATH 
     ${FACE_TRACKER_BINARY_DIR}/bin
)

SET( FACE_TRACKER_SRCS
     ${CMAKE_SOURCE_DIR}/src/exe/face_tracker.cc
     ${CMAKE_SOURCE_DIR}/src/lib/CLM.cc
     ${CMAKE_SOURCE_DIR}/src/lib/FCheck.cc
	 ${CMAKE_SOURCE_DIR}/src/lib/FDet.cc
	 ${CMAKE_SOURCE_DIR}/src/lib/IO.cc
	 ${CMAKE_SOURCE_DIR}/src/lib/Patch.cc
	 ${CMAKE_SOURCE_DIR}/src/lib/PAW.cc
	 ${CMAKE_SOURCE_DIR}/src/lib/PDM.cc
	 ${CMAKE_SOURCE_DIR}/src/lib/Tracker.cc
	
	${CMAKE_SOURCE_DIR}/include/FaceTracker/CLM.h
	${CMAKE_SOURCE_DIR}/include/FaceTracker/FCheck.h
	${CMAKE_SOURCE_DIR}/include/FaceTracker/FDet.h
	${CMAKE_SOURCE_DIR}/include/FaceTracker/IO.h
	${CMAKE_SOURCE_DIR}/include/FaceTracker/Patch.h
	${CMAKE_SOURCE_DIR}/include/FaceTracker/PAW.h
	${CMAKE_SOURCE_DIR}/include/FaceTracker/PDM.h
	${CMAKE_SOURCE_DIR}/include/FaceTracker/Tracker.h
	${CMAKE_SOURCE_DIR}/fips/EmotionClassifier.h
	${CMAKE_SOURCE_DIR}/fips/FaceShape.h
	${CMAKE_SOURCE_DIR}/fips/Stabilisator.h
	${CMAKE_SOURCE_DIR}/fips/plugin.cpp	
   )
   
ADD_EXECUTABLE( FACE_TRACKER ${FACE_TRACKER_SRCS})
TARGET_LINK_LIBRARIES( FACE_TRACKER ${OpenCV_LIBS})