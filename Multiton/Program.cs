using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiton
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Camera camera1 = Camera.GetCamera("NIKON1");
            Camera camera2 = Camera.GetCamera("NIKON1");
            Camera camera3 = Camera.GetCamera("CANON1");
            Camera camera4 = Camera.GetCamera("CANON1");

            Console.WriteLine(camera1.CameraId);
            Console.WriteLine(camera2.CameraId);
            Console.WriteLine(camera3.CameraId);
            Console.WriteLine(camera4.CameraId);

            Console.ReadLine(); 
        }
    }

    class Camera
    {
        static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
        static object _lock = new object();
        public Guid CameraId { get; private set; }
        private Camera()
        {
            CameraId = Guid.NewGuid();
        }

        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if (!_cameras.ContainsKey(brand))
                {
                    _cameras.Add(brand, new Camera());
                }
            }
            return _cameras[brand];
        }
    }
}
