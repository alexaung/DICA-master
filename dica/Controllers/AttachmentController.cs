using dica.Models;
using dica.Repositories;
using System;
using System.IO;
using System.Web.Mvc;
using System.Web.Routing;

namespace dica.Controllers
{
    public class AttachmentController : Controller
    {
        // GET: Attachment
        public ActionResult Index(string id)
        {
            var vm = new AttachmentViewModel();
            vm.UID = new Guid(id);
            vm.Attachments = AttachmentRepository.GetAttachments(vm.UID);
            return View(vm);
        }

        // GET: Attachment/Details/5
        public ActionResult Details(Guid id)
        {
            Attachment attachment = AttachmentRepository.GetAttachment(id);
            return View(attachment);
        }

        // GET: Attachment/Create
        public ActionResult Attach(string id)
        {
            var vm = new AttachmentViewModel();
            vm.UID = new Guid(id);
            return PartialView("AttachFormPartial", vm);
        }

        // POST: Attachment/Create
        [HttpPost]
        public ActionResult UploadFile(string id)
        {
            try
            {
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        Attachment attachment = new Attachment();
                        attachment.InvestmentId = new Guid(id);
                        attachment.Name = fileContent.FileName;
                        attachment.ContentLength = fileContent.ContentLength;
                        attachment.ContentType = fileContent.ContentType;

                        byte[] data;
                        using (Stream inputStream = fileContent.InputStream)
                        {
                            MemoryStream memoryStream = inputStream as MemoryStream;
                            if (memoryStream == null)
                            {
                                memoryStream = new MemoryStream();
                                inputStream.CopyTo(memoryStream);
                            }
                            data = memoryStream.ToArray();
                        }
                        attachment.Data = data;

                        AttachmentRepository.Insert(attachment);
                    }
                    else
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                        return Json("Upload failed");
                    }
                }
            }
            catch (Exception)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return Json("Upload failed");
            }

            return Json("File uploaded successfully");
        }

        public FileResult DownloadFile(string id)
        {
            var attach = AttachmentRepository.GetAttachment(new Guid(id));
            return File(attach.Data, attach.ContentType, attach.Name);
        }

        // GET: Attachment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Attachment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Attachment/Delete/5
        public ActionResult Delete(Guid id)
        {
            var attachment = AttachmentRepository.GetAttachment(id);
            return View(attachment);
        }

        // POST: Attachment/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var attachment = AttachmentRepository.GetAttachment(id);
                AttachmentRepository.Delete(id);
                //return RedirectToAction("Index", attachment.InvestmentId);
                return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Attachment", action = "Index", Id = attachment.InvestmentId }));
            }
            catch
            {
                return View();
            }
        }
    }
}
