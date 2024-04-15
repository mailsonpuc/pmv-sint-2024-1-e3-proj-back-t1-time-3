using System.Security.Claims;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nickolas_mendonca_feed_aluno.Models;

namespace nickolas_mendonca_feed_aluno.Controllers
{
    []
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var dados = await _context.Usuarios.ToListAsync();
            return View(dados);
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            var dados = await _context.Usuarios
                .FindAsync(usuario.Senha);

            if (dados == null)
            {
                ViewBag.Message = "Usuario ou senha invalido";
                return View();
            }

            bool senhaOk = BCrypt.Net.BCrypt.Verify(usuario.Senha, dados.Senha);

            if (senhaOk)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, dados.Nome),
                    new Claim(ClaimTypes.NameIdentifier, dados.Id.ToString()),
                    new Claim(ClaimTypes.Role, dados.TipoUsuario.ToString())
                };

                var usuarioIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(principal, props);

                return Redirect("/");

            }
            else
            {
                ViewBag.Message = "Usuario ou senha invalido";
            }

            return View();
        }

        //metodo Get para poder exibir o formulario ao usuario
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // daodos preenchidos pelos dados do usuario
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Senha,TipoUsuario")] Usuario usuario) 
        {
            if(ModelState.IsValid) 
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                _context.Usuarios.Add(usuario);
                 await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public async Task<IActionResult> Edit(int? id) 
        {
            if(id == null) return NotFound();

            var dados = await _context.Usuarios.FindAsync(id);

            if(dados == null) return NotFound();

            return View(dados);    
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
        {
            if(id != usuario.Id) return NotFound();

            if(ModelState.IsValid)
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null) return NotFound();

            var dados = await _context.Usuarios.FindAsync(id);

            if(dados == null) return NotFound();

            return View(dados); 
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var dados = await _context.Usuarios.FindAsync(id);

            if (dados == null) return NotFound();

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null) return NotFound();

            var dados = await _context.Usuarios.FindAsync(id);

            if (dados == null) return NotFound();

            _context.Usuarios.Remove(dados);  
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
