using dica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace dica.Repositories
{
    public class AttachmentRepository
    {
        public static int Insert(Attachment attachment)
        {
            using (var db = new ApplicationDbContext())
            {
                attachment.UID = Guid.NewGuid();
                db.Attachments.Add(attachment);
                return db.SaveChanges();
            }
        }

        public static int Update(Attachment attachment)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Attachments.Attach(attachment);
                db.Entry(attachment).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public static List<Attachment> GetAttachments(Guid investmentId)
        {
            using (var db = new ApplicationDbContext())
            {
                var query = from attachment in db.Attachments
                            where attachment.InvestmentId == investmentId
                            select attachment;
                return query.ToList();
            }
        }

        public static Attachment GetAttachment(Guid uid)
        {
            using (var db = new ApplicationDbContext())
            {
                var query = from attachment in db.Attachments
                            where attachment.UID == uid
                            select attachment;
                return query.FirstOrDefault(); 
            }
        }

        public static int Delete(Guid uid)
        {
            using (var db = new ApplicationDbContext())
            {
                var attach = db.Attachments.Where(t => t.UID == uid).FirstOrDefault();
                db.Attachments.Remove(attach);
                return db.SaveChanges();
            }
        }

        public static bool IsExit(Guid uid)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Attachments.Any(t => t.UID == uid);
            }
        }
    }
}