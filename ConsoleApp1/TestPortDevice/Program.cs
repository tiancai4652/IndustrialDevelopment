using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPortDevice
{
    class Program
    {
        static SerialPort _serialPort;
        static void Main(string[] args)
        {
            _serialPort = new SerialPort("COM5");
            _serialPort.Open();
            string response = SendCommand("GetSeriesNumber");
        }

        /// <summary>
        /// Send command to the device
        /// </summary>
        /// <param name="message">String command without carriage return (\r) character to send to the device</param>
        /// <returns>Device response without carriage return (\r) and newline (\n) characters</returns>
        static string SendCommand(string message)
        {
            message += "\r\n";

            if (!_serialPort.IsOpen)
            {
                _serialPort.Open();
            }
            _serialPort.Write(message);

            // Response is trimmed of \r\n when read
            // TODO: this response parsing assumes that responses are complete; to make more robust
            string response = _serialPort.ReadTo("\r\n") + _serialPort.ReadTo("\r\n");

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }

            return "";
            //if (response.StartsWith("ok", StringComparison.OrdinalIgnoreCase))
            //{
            //    if (_serialPort.IsOpen)
            //    {
            //        _serialPort.Close();
            //    }

            //    // Remove "ok" from the response string that is returned, and trim spaces
            //    return response.Substring("ok".Length).Trim();
            //}
            //else if (response.StartsWith("err"))
            //{
            //    if (_serialPort.IsOpen)
            //    {
            //        _serialPort.Close();
            //    }
            //    switch (response)
            //    {
            //        case "err \"Invalid Value\"":
            //            throw new ArgumentException("Invalid value");
            //        case "err \"Missing Parameter\"":
            //            throw new ArgumentException("Missing Parameter");
            //        case "err \"Invalid Parameter\"":
            //            throw new ArgumentException("Invalid Parameter");
            //        case "err":
            //        default:
            //            throw new Exception("A generic error occured");
            //    }
            //}
            //else
            //{
            //    if (_serialPort.IsOpen)
            //    {
            //        _serialPort.Close();
            //    }
            //    throw new IOException("Device response was not understood.");
            //}
        }
    }
}
