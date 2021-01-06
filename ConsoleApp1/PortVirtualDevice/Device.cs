using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortVirtualDevice
{
    public class Device
    {
        static int SN = 20210106;
        SerialPort _serialPort;

        #region Other

        Object thisLock = new Object();

        #endregion

        #region 信息字段

        /// <summary>
        /// SN
        /// </summary>
        string seriesNumber = (SN++).ToString();
        /// <summary>
        /// 设备型号
        /// </summary>
        string deviceModel = "PortDevice";
        /// <summary>
        /// 串口号
        /// </summary>
        string portName;
        /// <summary>
        /// 结束符
        /// </summary>
        string stopChar;
        /// <summary>
        /// 湿度
        /// </summary>
        string humidity = "30";
        /// <summary>
        /// 温度
        /// </summary>
        string tempterature = "28.6";

        DataTY _DataTYCurrent;
        /// <summary>
        /// 当前设备的TY型数据(演示用)
        /// </summary>
        DataTY DataTYCurrent
        {
            get
            {
                return _DataTYCurrent;
            }
            set
            {
                lock (thisLock)
                {
                    _DataTYCurrent = value;
                }
            }
        }




        DataXY _DataXYCurrent;
        /// <summary>
        /// 当前设备的XY型数据(演示用)
        /// </summary>
        DataXY DataXYCurrent
        {
            get
            {
                return _DataXYCurrent;
            }
            set
            {
                lock (thisLock)
                {
                    _DataXYCurrent = value;
                }
            }
        }

        #endregion

        #region 存储字段（有些设备内部会有一些储存数据,此数据需要上传到电脑上）

        List<DataTY> dataTYList;

        List<DataXY> dataXYList;

        #endregion

        #region 设置字段



        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="portName">COM1/COM2</param>
        public Device(string portName, string stopChar = "\r\n")
        {
            this.stopChar = stopChar;
            this.portName = portName;
            _serialPort = new SerialPort(portName);
            dataTYList = new List<DataTY>();
            dataXYList = new List<DataXY>();
            DataTYCurrent = new DataTY(0, DateTime.Now);
            DataXYCurrent = new DataXY(0, 0);
        }

        public void Load()
        {
            _serialPort.Open();

            double x = 0;
            double y = 0;

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    y = Math.Round(100 * Math.Sin(x / 20), 4);
                    DataTYCurrent.Time = DateTime.Now;
                    DataTYCurrent.Y = y;
                    DataXYCurrent.X = x;
                    DataXYCurrent.Y = y;
                }
            });

            while (true)
            {
                ReadAndRespond();
            }
        }

        void ReadAndRespond()
        {
            try
            {
                string message = _serialPort.ReadTo(stopChar);
                message = message.Replace(stopChar, "");
                string response = "";
                //Get
                if (message.StartsWith("Get"))
                {
                    switch (message)
                    {
                        //获取SN号
                        case "GetSeriesNumber":
                            response = stopChar + seriesNumber + stopChar;
                            break;
                        //获取设备时间
                        case "GetDatetime":
                            response = stopChar + DateTime.Now.ToShortDateString() + stopChar;
                            break;
                        //获取设备型号
                        case "GetDeviceModel":
                            response = stopChar + deviceModel + stopChar;
                            break;
                        //获取温度
                        case "GetDeviceTempterature":
                            response = stopChar + tempterature + stopChar;
                            break;
                        //获取温度
                        case "GetDeviceHumidity":
                            response = stopChar + humidity + stopChar;
                            break;
                        default:
                            break;

                    }
                }
                //Set
                if (message.StartsWith("Set"))
                {
                    var para = message.Split(' ');
                    var cmd = para[0];
                    var info = para[1];
                    switch (message)
                    {
                        //设置SN号
                        case "SeriesNumber":
                            seriesNumber = info;
                            break;
                        //设备设备型号
                        case "SetDeviceModel":
                            deviceModel = info;
                            break;
                    }
                }
                //RunTask
                if (message.StartsWith("Run"))
                {

                }
                if (!string.IsNullOrEmpty(response))
                {
                    _serialPort.Write(response);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
