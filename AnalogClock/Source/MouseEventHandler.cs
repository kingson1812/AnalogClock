using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnalogClock.Source
{
   public class MouseEventHandler
    {
        public MouseEventHandler()
        { }

        public static MouseEventHandler GetInstance()
        {
            return s_Instance;
        }

        public static void CreateInstance()
        {
            s_Instance = new MouseEventHandler();
        }

        public void OnLeftClickDown()
        {
            
        }

        private static MouseEventHandler s_Instance;

    }
}
