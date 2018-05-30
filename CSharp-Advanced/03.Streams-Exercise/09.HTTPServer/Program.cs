using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _09.HTTPServer
{
    class Program
    {

        private const int PortNumber = 1337;
        private const string SourcePath = "../../Source";

        public static void Main()
        {
            var tcpListener = new TcpListener(IPAddress.Any, PortNumber);
            tcpListener.Start();

            Console.WriteLine($"Listening on port {PortNumber}...");
            Console.WriteLine($"The local End point is : {tcpListener.LocalEndpoint}");

            while (true)
            {
                using (NetworkStream networkStream = tcpListener.AcceptTcpClient().GetStream())
                {
                    var request = new byte[4096];
                    var readBytes = networkStream.Read(request, 0, request.Length);

                    var reqData = Encoding.UTF8.GetString(request, 0, readBytes).Replace("\\", "/");
                    Console.WriteLine(reqData);

                    if (!string.IsNullOrEmpty(reqData))
                    {
                        var file = string.Empty;

                        var reqFirstLine = reqData.Substring(0, reqData.IndexOf(Environment.NewLine)).Split();
                        var url = reqFirstLine[1];
                        var statusLine = $"{reqFirstLine[2]} 200 OK";

                        if (url == "/")
                        {
                            file = $"{SourcePath}/index.html";
                        }
                        else
                        {
                            var reqFile = $"{SourcePath}{url.Substring(url.IndexOf('/'))}";

                            if (!reqFile.EndsWith(".html"))
                            {
                                reqFile += ".html";
                            }

                            if (File.Exists(reqFile))
                            {
                                file = reqFile;
                            }
                            else
                            {
                                statusLine = "HTTP/1.0 404 Not Found";
                            }
                        }

                        var responseHeader = new StringBuilder();
                        responseHeader.Append($"{statusLine}{Environment.NewLine}");
                        responseHeader.Append($"Accept-Ranges: bytes{Environment.NewLine}");
                        var response = new StringBuilder();
                        using (var reader = new StreamReader(file))
                        {
                            var line = reader.ReadLine();

                            while (line != null)
                            {
                                response.Append(line);
                                line = reader.ReadLine();
                            }
                        }

                        if (file.EndsWith("info.html"))
                        {
                            response
                                .Replace("{0}", DateTime.Now.ToString("dd MMM yyyy hh:mm:ss", new CultureInfo("en-EN")))
                                .Replace("{1}", Environment.ProcessorCount.ToString());
                        }
                        var contentLingth = Encoding.UTF8.GetBytes(response.ToString()).Length;

                        responseHeader.Append($"ContentLength: {contentLingth}{Environment.NewLine}");
                        responseHeader.Append($"Connection: close{Environment.NewLine}");
                        responseHeader.Append($"Content-Type: text/html{Environment.NewLine}");
                        responseHeader.Append(Environment.NewLine);
                        response.Insert(0, responseHeader);
                        var responseBytes = Encoding.UTF8.GetBytes(response.ToString());
                        networkStream.Write(responseBytes, 0, responseBytes.Length);
                    }
                }
            }
        }
    }
}