using System;
using System.Drawing;
using System.Globalization;

namespace DevExpress.Logify.Core {
    public class DisplayCollector : IInfoCollector {
        public virtual void Process(Exception ex, ILogger logger) {
            //Size size = System.Windows.Forms.SystemInformation.WorkingArea.Size;
            Size size = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            logger.BeginWriteObject("display");
            try {
                logger.WriteValue("width", size.Width.ToString());
                logger.WriteValue("height", size.Height.ToString());

                PointF dpi = GetDpi();
                if (dpi.IsEmpty) {
                    logger.WriteValue("dpiX", dpi.X.ToString(CultureInfo.InvariantCulture));
                    logger.WriteValue("dpiY", dpi.Y.ToString(CultureInfo.InvariantCulture));
                }

                //logger.WriteValue("os", "Windows :)");
            }
            finally {
                logger.EndWriteObject("display");
            }
        }

        PointF GetDpi() {
            try {
                Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
                return new PointF(gr.DpiX, gr.DpiY);
            }
            catch {
                return PointF.Empty;
            }
        }
    }
}
