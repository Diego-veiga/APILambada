using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILambada.Data;
using APILambada.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace APILambada.Controllers
{
    [Route("Usuario")]
    public class UsuariosController : Controller
    {
        [Route("")]
        [HttpGet]
        public async Task<ActionResult<List<Usuarios>>> ListaUsuarios([FromServices]LambadaContext context)
        {
            try
            {
                var usuarios = await context.Usuarios.AsNoTracking().ToListAsync();
                return usuarios;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel trazer a lista de usuários" });
            }
        }
        [Route("{id:int}")]
        [HttpGet]
        public async Task<ActionResult<Usuarios>> UsuarioPorId(int id, [FromServices]LambadaContext context)
        {
            try
            {
                var usuario = await context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
                return usuario;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel buscar usuario" });
            }

        }
        [Route("")]
        [HttpPost]
        public async Task<ActionResult<Usuarios>> CadastraUsuario([FromServices]LambadaContext context, [FromBody]Usuarios model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Objecto inaválido" });
            }
            try
            {
                context.Add(model);
                await context.SaveChangesAsync();
                return Ok(new { message = "usuário cadastrado com sucesso" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Não foi possivel cadastrar usuario" });
            }


        }
        [Route("{id:int}")]
        [HttpPut]
        public async Task<ActionResult<Usuarios>> AtualizarUsuario(int id, [FromServices]LambadaContext context, [FromBody]Usuarios model)
        {
            if (model.Id != id)
            {
                return BadRequest(new { message = "id informado incorretamnet" });

            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Objecto inaválido" });

            }
            try
            {
                context.Entry<Usuarios>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(new { message = "Usuario modificado com sucesso" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel atualziar o usuario" });
            }

        }
        [Route("{id:int}")]
        [HttpDelete]
        public async Task<ActionResult<String>> DeletaUsuario(int id, [FromServices]LambadaContext context)
        {
            try
            {
                var usuario = await context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (usuario == null)
                {
                    return Ok(new { message = "Não existe nenhum usuario cadastrado com este id" });
                }
                context.Remove(usuario);
                await context.SaveChangesAsync();
                return Ok(new { message = "Usuario excluído com sucesso" });

            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel deletar o usuario" });
            }



        }
    }
}