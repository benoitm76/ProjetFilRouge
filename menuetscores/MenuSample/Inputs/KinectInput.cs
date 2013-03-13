using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System.IO;

namespace TestKinect
{
    public delegate void playerFired();
    public delegate void playerMoved();
    public class KinectInput
    {
        public KinectSensor sensor { get; set; }
        public event playerFired playerFire;
        public event playerFired startFire;
        public event playerFired stopFire;
        public event playerMoved playerMove;
        public bool onContinueFire { get; set; }
        public bool onFire { get; set; }

        public SkeletonPoint oldPointLeftHand { get; set; }
        public SkeletonPoint oldPointRightHand { get; set; }

        public KinectInput()
        {
            if (KinectSensor.KinectSensors[0] != null)
            {
                this.sensor = KinectSensor.KinectSensors[0];
                sensor.SkeletonStream.Enable();
                try
                {
                    this.sensor.Start();
                }
                catch (IOException)
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new Exception();
            }
            onContinueFire = false;

            sensor.SkeletonFrameReady += onSkeletonFrameReady;
        }

        private void onSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            bool receivedData = false;
            Skeleton[] skeletons = new Skeleton[0];
            using (SkeletonFrame SFrame = e.OpenSkeletonFrame())
            {
                if (SFrame == null)
                {
                    // The image processing took too long. More than 2 frames behind.
                }
                else
                {
                    skeletons = new Skeleton[SFrame.SkeletonArrayLength];
                    SFrame.CopySkeletonDataTo(skeletons);
                    receivedData = true;
                }
            }

            if (receivedData)
            {
                Skeleton currentSkeleton = (from s in skeletons
                                            where s.TrackingState ==
                                            SkeletonTrackingState.Tracked
                                            select s).FirstOrDefault();

                if (currentSkeleton != null)
                {
                    if ((oldPointRightHand.Z - currentSkeleton.Joints[JointType.HandRight].Position.Z >= 0.3) && !onFire)
                    {
                        oldPointRightHand = currentSkeleton.Joints[JointType.HandRight].Position;
                        if (onContinueFire)
                        {
                            startFire();
                            onFire = true;
                        }
                        else
                        {
                            playerFire();
                        }
                    }
                    else if ((currentSkeleton.Joints[JointType.HandRight].Position.Z - oldPointRightHand.Z >= 0.3) && onFire)
                    {
                        oldPointRightHand = currentSkeleton.Joints[JointType.HandRight].Position;
                        stopFire();
                        onFire = false;
                    }
                    else if ((oldPointRightHand.Z < currentSkeleton.Joints[JointType.HandRight].Position.Z) && !onFire)
                    {
                        oldPointRightHand = currentSkeleton.Joints[JointType.HandRight].Position;
                    }
                    else if ((oldPointRightHand.Z > currentSkeleton.Joints[JointType.HandRight].Position.Z) && onFire)
                    {
                        oldPointRightHand = currentSkeleton.Joints[JointType.HandRight].Position;
                    }

                    if (Math.Abs(oldPointLeftHand.X - currentSkeleton.Joints[JointType.HandLeft].Position.X) >= 0.005 || Math.Abs(oldPointLeftHand.Y - currentSkeleton.Joints[JointType.HandLeft].Position.Y) >= 0.005)
                    {
                        oldPointLeftHand = currentSkeleton.Joints[JointType.HandLeft].Position;
                        playerMove();
                    }
                }
            }
        }
    }
}
