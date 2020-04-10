using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ness.ExemploWeb.Dominio.Entidades;
using Ness.ExemploWeb.Dominio.Repositorios;
using Ness.ExemploWeb.Dominio.Servicos;
using Ness.ExemploWeb.Dtos;
using Omu.ValueInjecter;

namespace Ness.ExemploWeb.Web.Controllers
{
    public class AgendaController : Controller
    {

        private readonly IServicoAgenda servicoAgenda;
        private readonly IUnitOfWork unitOfWork;

        public AgendaController(IServicoAgenda servicoAgenda, IUnitOfWork unitOfWork)
        {
            this.servicoAgenda = servicoAgenda ?? throw new ArgumentNullException(nameof(servicoAgenda));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        // GET: Agenda
        public ActionResult Index(long id)
        {
            var agenda = servicoAgenda.ObterAgendaPaciente(id);
            List<AgendaModel> agendaModel = TransformarAgendasEmModel(agenda);
            return View(agendaModel);
        }

        private static List<AgendaModel> TransformarAgendasEmModel(IEnumerable<Agenda> agendas)
        {
            List<AgendaModel> agendasModel = new List<AgendaModel>();
            foreach (var agenda in agendas)
            {
                AgendaModel agendaModel = TransformarAgendaEmModel(agenda);
                agendasModel.Add(agendaModel);
            }

            return agendasModel;
        }

        private static AgendaModel TransformarAgendaEmModel(Agenda agenda)
        {
            AgendaModel agendaModel = new AgendaModel();
            agendaModel.InjectFrom(agenda);
            return agendaModel;
        }


        // GET: Agenda/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Agenda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agenda/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Agenda/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Agenda/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Agenda/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Agenda/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}