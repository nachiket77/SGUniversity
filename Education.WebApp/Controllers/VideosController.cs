using Education.Core.Admin;
using Education.Entity.Admin;
using Education.Entity.Admin.Videos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.WebApp.Controllers
{
    public class VideosController : Controller
    {
        IVideoUpload _VideoUpload;
        VideoUploaddetails objvideodetails = new VideoUploaddetails();
        public VideosController(IVideoUpload VideoUploaddetails)
        {
            this._VideoUpload = VideoUploaddetails;
        }
        // GET: Videos
        public ActionResult Index()
        {
            AllVideosDetails objalldetails = new AllVideosDetails();
            objalldetails.CourseList = _VideoUpload.GetCourse();
            objalldetails.SubjectList = _VideoUpload.Getsubject();

            objalldetails.VideoUploaddetailsList = _VideoUpload.GetVideoUploaddetails();
            VideoUploaddetails dt = new VideoUploaddetails();
            dt.DIGITALDOCTYPEID = 1;

            // return View();
            return View(objalldetails);
        }

        public ActionResult AddVideo()
        {
            AllVideosDetails objalldetails = new AllVideosDetails();
            objalldetails.CourseList = _VideoUpload.GetCourse();
            objalldetails.SubjectList = _VideoUpload.Getsubject();
            objalldetails.VideoUploaddetailsList = _VideoUpload.GetVideoUploaddetails();
            //objalldetails.VideoUploaddetails.DIGITALDOCTYPEID = 1;
            return View(objalldetails);
        }



        [HttpPost]
        public ActionResult AddVideo(HttpPostedFileBase postedFile, AllVideosDetails objvideo, FormCollection form)
        {

            if (ModelState.IsValid)
            {
                if (postedFile != null && postedFile.ContentLength > 0)
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/files"),
                        Path.GetFileName(postedFile.FileName));
                        postedFile.SaveAs(path);
                        ViewBag.Message = "File uploaded successfully";
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                else
                {
                    ViewBag.Message = "You have not specified a file.";
                }


                //   var selectedItem = objvideo.CourseMaster.ID;
                //  objvideoupload.SubjectMaster.SUBJECTID = objvideo.SubjectMaster.SUBJECTID;
                //foreach (var item in objvideo.VideoUploaddetailsList)
                //{
                //    objvideoupload.VideoUploaddetails.DIGITALDOCTYPEID = item.DIGITALDOCTYPEID;
                //    objvideoupload.VideoUploaddetails.DOCUMENTNAME = Path.GetFileName(postedFile.FileName);
                //}
                objvideodetails.DIGITALDOCTYPEID = 1;
                objvideodetails.DOCUMENTNAME = Path.GetFileName(postedFile.FileName);
                objvideo.VideoUploaddetails = objvideodetails;
                objvideo = _VideoUpload.CreateVideoDetails(objvideo);

            }

            return View(GetFiles());





            //return View(GetFiles());
        }
        public ActionResult ListVideo()
        {
            return View();
        }

        [HttpGet]
        public FileResult DownloadFile(int? DIGITALDOCID)
        {
            byte[] bytes;
            string fileName, contentType;
            byte[] value;
                List<VideoUploaddetails> objvideoupload = new List<VideoUploaddetails>();
            objvideoupload = _VideoUpload.GetFileName(Convert.ToInt32(DIGITALDOCID));
            //fileName = objvideoupload.SingleOrDefault().DOCUMENTNAME;
            foreach (var item in objvideoupload)
            {
                fileName = item.DOCUMENTNAME;
                string path = Path.Combine(Server.MapPath("~/Content/files"), fileName);
                //TransmitFile(path, fileName);
                //readinchuks(path, Convert.ToInt32(DIGITALDOCID));
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                 value = ReadFullyvideo(fs, Convert.ToInt32(fs.Length));
                break;
            }

            //foreach (var item in objvideoupload)
            //{
            //    fileName = item.DOCUMENTNAME;
            //}




            byte[] byt;
            //using (FileStream fs = new FileStream(path, FileMode.Open))
            //{

            // }


            // bytes = System.IO.File.ReadAllBytes(path);


            return File("video/mp4", "");
        }

        public List<VideoUploaddetails> GetFiles()
        {
            List<VideoUploaddetails> objvideoupload = new List<VideoUploaddetails>();
            objvideoupload = _VideoUpload.GetVideoUploaddetails();
            return objvideoupload;
        }

        public static byte[] ReadFully(Stream stream, int initialLength)
        {
            // If we've been passed an unhelpful initial length, just
            // use 32K.
            if (initialLength < 1)
            {
                initialLength = 32768;
            }

            byte[] buffer = new byte[initialLength];
            int read = 0;

            int chunk;
            while ((chunk = stream.Read(buffer, read, buffer.Length - read)) > 0)
            {
                read += chunk;

                // If we've reached the end of our buffer, check to see if there's
                // any more information
                if (read == buffer.Length)
                {
                    int nextByte = stream.ReadByte();

                    // End of stream? If so, we're done
                    if (nextByte == -1)
                    {
                        return buffer;
                    }

                    // Nope. Resize the buffer, put in the byte we've just
                    // read, and continue
                    byte[] newBuffer = new byte[buffer.Length * 2];
                    Array.Copy(buffer, newBuffer, buffer.Length);
                    newBuffer[read] = (byte)nextByte;
                    buffer = newBuffer;
                    read++;
                }
            }
            // Buffer is now too big. Shrink it.
            byte[] ret = new byte[read];
            Array.Copy(buffer, ret, read);
            return ret;
        }

        private void TransmitFile(string fullPath, string outFileName)
        {
            System.IO.Stream iStream = null;

            // Buffer to read 10K bytes in chunk:
            byte[] buffer = new Byte[10000];

            // Length of the file:
            int length;

            // Total bytes to read:
            long dataToRead;

            // Identify the file to download including its path.
            string filepath = fullPath;

            // Identify the file name.
            string filename = System.IO.Path.GetFileName(filepath);

            try
            {
                // Open the file.
                iStream = new System.IO.FileStream(filepath, System.IO.FileMode.Open,
                            System.IO.FileAccess.Read, System.IO.FileShare.Read);


                // Total bytes to read:
                dataToRead = iStream.Length;

                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + outFileName);
                Response.AddHeader("Content-Length", iStream.Length.ToString());

                // Read the bytes.
                while (dataToRead > 0)
                {
                    // Verify that the client is connected.
                    if (Response.IsClientConnected)
                    {
                        // Read the data in buffer.
                        length = iStream.Read(buffer, 0, 10000);

                        byte[] TrimmedBuffer = new byte[dataToRead];
                        Array.Copy(buffer, TrimmedBuffer, dataToRead);
                        buffer = TrimmedBuffer;


                        // Write the data to the current output stream.
                        Response.OutputStream.Write(buffer, 0, length);

                        // Flush the data to the output.
                        Response.Flush();

                        buffer = new Byte[10000];
                        dataToRead = dataToRead - length;


                    }
                    else
                    {
                        //prevent infinite loop if user disconnects
                        dataToRead = -1;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                if (iStream != null)
                {
                    //Close the file.
                    iStream.Close();
                }
                Response.Close();
            }

            //return ms.ToArray();
        }

        private void readinchuks(string FilePath, int digitaldocid)
        {
            // the file that we want to upload
            // string FilePath = @"C:\Ajay Education app\EducationAppnew\EducationApp\EducationApp\Education.WebApp\Content\files\VTS_01_2.VOB";

            int Offset = 0; // starting offset.
            byte[] intBytes, result;
            //define the chunk size
            int ChunkSize = 65536; // 64 * 1024 kb

            //define the buffer array according to the chunksize.
            byte[] Buffer = new byte[ChunkSize];
            //opening the file for read.
            FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            //creating the ServiceSoapClient which will allow to connect to the service.
            // WSservice.ServiceSoapClient soap_client = new WSservice.ServiceSoapClient();
            try
            {
                long FileSize = new FileInfo(FilePath).Length; // File size of file being uploaded.
                                                               // reading the file.
                fs.Position = Offset;
                int BytesRead = 0;
                while (Offset != FileSize) // continue uploading the file chunks until offset = file size.
                {
                    BytesRead = fs.Read(Buffer, 0, ChunkSize); // read the next chunk 
                                                               // (if it exists) into the buffer. 
                                                               // the while loop will terminate if there is nothing left to read
                                                               // check if this is the last chunk and resize the buffer as needed 
                                                               // to avoid sending a mostly empty buffer 
                                                               // (could be 10Mb of 000000000000s in a large chunk)
                    if (BytesRead == Buffer.Length)
                    {
                        ChunkSize = BytesRead;
                        byte[] TrimmedBuffer = new byte[BytesRead];
                        Array.Copy(Buffer, TrimmedBuffer, BytesRead);
                        Buffer = TrimmedBuffer; // the trimmed buffer should become the new 'buffer'
                    }
                    // send this chunk to the server. it is sent as a byte[] parameter, 
                    // but the client and server have been configured to encode byte[] using MTOM. 
                    //FileResult ChunkAppened = DownloadFile(digitaldocid, Buffer, Offset);
                    //if (!ChunkAppened)
                    //{
                    //    break;
                    //}

                    // Offset is only updated AFTER a successful send of the bytes. 
                    Offset += BytesRead; // save the offset position for resume

                }


            }

            catch (Exception ex)
            {
            }
            finally
            {
                fs.Close();
            }


        }

        public static byte[] ReadFullyvideo(Stream stream, int initialLength)
        {
            // If we've been passed an unhelpful initial length, justS
            // use 32K.
            if (initialLength < 1)
            {
                initialLength = 32768;
            }

            byte[] buffer = new byte[3824726];
            int read = 0;
            int chunk;
            try
            {

                while ((chunk = stream.Read(buffer, read, 3824726 - read)) > 0)
                {
                    Console.WriteLine("Length of chunk" + chunk);
                    read += chunk;
                    Console.WriteLine("Length of read" + read);
                    if (read == 0)
                    {
                        stream.Close();
                        return buffer;
                    }
                    // If we've reached the end of our buffer, check to see if there's
                    // any more information
                    if (read == buffer.Length)
                    {
                        Console.WriteLine("Length of Buffer" + buffer.Length);
                        int nextByte = stream.ReadByte();

                        // End of stream? If so, we're done
                        if (nextByte == -1)
                        {
                            return buffer;
                        }

                        // Nope. Resize the buffer, put in the byte we've just
                        // read, and continue
                        byte[] newBuffer = new byte[buffer.Length * 2];
                        Console.WriteLine("Length of newBuffer" + newBuffer.Length);
                        Array.Copy(buffer, newBuffer, buffer.Length);
                        newBuffer[read] = (byte)nextByte;
                        buffer = newBuffer;
                        read++;
                    }
                }

                // Buffer is now too big. Shrink it.
                byte[] ret = new byte[read];
                Array.Copy(buffer, ret, read);
                return ret;
            }
            catch (Exception ex)
            { throw ex; }
        }



    }
}