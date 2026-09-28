using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PcmLesson07Annotation.Models;

namespace PcmLesson07Annotation.Controllers
{
    public class PcmMemberController : Controller
    {
        
        // Danh sách thành viên
        private static List<PcmMember> PcmMembers = new List<PcmMember>();

        // GET: PcmMemberController
        public ActionResult Index()
        {
            // Truyền danh sách thành viên sang View
            return View(PcmMembers);
        }

        // GET: PcmMemberController/Details/5
        public ActionResult Details(int id)
        {
            var member = PcmMembers.FirstOrDefault(x => x.Id == id);

            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: PcmMemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PcmMemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PcmMember pcmMember)
        {
            if (!ModelState.IsValid)
            {
                return View(pcmMember);
            }
 
           PcmMembers.Add(pcmMember);

            // Tạo Id tự động
            pcmMember.Id = PcmMembers.Count + 1;

            // Thêm thành viên vào danh sách
            PcmMembers.Add(pcmMember);

            // Quay về trang Index
            return RedirectToAction(nameof(Index));
        }

        // GET: PcmMemberController/Edit/5
        public ActionResult Edit(int id)
        {
            var member = PcmMembers.FirstOrDefault(x => x.Id == id);

            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: PcmMemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PcmMember pcmMember)
        {
            if (!ModelState.IsValid)
            {
                return View(pcmMember);
            }

            var member = PcmMembers.FirstOrDefault(x => x.Id == id);

            if (member == null)
            {
                return NotFound();
            }

            member.PcmUsername = pcmMember.PcmUsername;
            member.Pcmpassword = pcmMember.Pcmpassword;
            member.PcmEmail = pcmMember.PcmEmail;
            member.PcmPhone = pcmMember.PcmPhone;

            return RedirectToAction(nameof(Index));
        }

        // GET: PcmMemberController/Delete/5
        public ActionResult Delete(int id)
        {
            var member = PcmMembers.FirstOrDefault(x => x.Id == id);

            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: PcmMemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var member = PcmMembers.FirstOrDefault(x => x.Id == id);

            if (member != null)
            {
                PcmMembers.Remove(member);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}