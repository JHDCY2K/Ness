using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ness.ExemploWeb.Dtos;
using Ness.ExemploWeb.Dominio.Entidades;
using Ness.ExemploWeb.Dominio.Repositorios;
using Ness.ExemploWeb.Dominio.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace Ness.ExemploWeb.Web.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly IServicoCliente servicoCliente;
        private readonly IServicoAgenda servicoAgenda;
        private readonly IUnitOfWork unitOfWork;

        public ClienteController(IServicoCliente servicoCliente, IServicoAgenda servicoAgenda, IUnitOfWork unitOfWork)
        {
            this.servicoCliente = servicoCliente ?? throw new ArgumentNullException(nameof(servicoCliente));
            this.servicoAgenda = servicoAgenda ?? throw new ArgumentNullException(nameof(servicoAgenda));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }



        // GET: Cliente
        public IActionResult Index()
        {
            var clientes = servicoCliente.ObterClientes();
            List<ClienteModel> clientesModel = TransformarClientesEmModel(clientes);
            return View(clientesModel);
        }

        private static List<ClienteModel> TransformarClientesEmModel(IEnumerable<Cliente> clientes)
        {
            List<ClienteModel> clientesModel = new List<ClienteModel>();
            foreach (var cliente in clientes)
            {
                ClienteModel clienteModel = TransformarClienteEmModel(cliente);
                clientesModel.Add(clienteModel);
            }

            return clientesModel;
        }

        private static ClienteModel TransformarClienteEmModel(Cliente cliente)
        {
            ClienteModel clienteModel = new ClienteModel();
            clienteModel.InjectFrom(cliente);
            return clienteModel;
        }


        // GET: Cliente/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = servicoCliente.ObterPorId(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }
            ClienteModel clienteModel = TransformarClienteEmModel(cliente);

            return View(clienteModel);
        }


        // GET: Cliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome,Endereco,CPF")] ClienteModel clienteModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cliente cliente = new Cliente();
                    cliente.InjectFrom(clienteModel);
                    servicoCliente.Inserir(cliente);
                    unitOfWork.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(clienteModel);
        }

        // GET: Cliente/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = servicoCliente.ObterPorId(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }
            ClienteModel clienteModel = TransformarClienteEmModel(cliente);
            return View(clienteModel);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int idCliente, [Bind("idCliente,Nome,Endereco,CPF")] ClienteModel clienteModel)
        {
            if (idCliente != clienteModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Cliente cliente = servicoCliente.ObterPorId(clienteModel.Id);
                    cliente.InjectFrom(clienteModel);

                    unitOfWork.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(clienteModel);
        }

        // GET: Cliente/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = servicoCliente.ObterPorId(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }
            ClienteModel clienteModel = TransformarClienteEmModel(cliente);

            return View(clienteModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cliente = servicoCliente.ObterPorId(id);
            servicoCliente.Remover(cliente);
            unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Agenda(long id)
        {
            var agenda = servicoAgenda.ObterAgendaPaciente(id);

            List<AgendaModel> agendassModel = TransformarAgendasEmModel(agenda);
            return View(agendassModel);


        }

        private static List<AgendaModel> TransformarAgendasEmModel(IEnumerable<Agenda> agendas)
        {
            List<AgendaModel> usuariosModel = new List<AgendaModel>();
            foreach (var agenda in agendas)
            {
                AgendaModel agendaModel = TransformarAgendaEmModel(agenda);
                usuariosModel.Add(agendaModel);
            }

            return usuariosModel;
        }

        private static AgendaModel TransformarAgendaEmModel(Agenda agenda)
        {
            AgendaModel clienteModel = new AgendaModel();
            clienteModel.InjectFrom(agenda);
            return clienteModel;
        }


    }
}