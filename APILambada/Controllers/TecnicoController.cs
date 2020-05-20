using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILambada.Data;
using APILambada.Model;
using APILambada.Model.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace APILambada.Controllers
{
    [Route("Tecnico")]
    public class TecnicoController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Tecnico>>> TodosTencicos([FromServices]LambadaContext context)
        {
            try
            {
                var Tecnicos = await context.Tecnico.AsNoTracking().ToListAsync();
                return Ok(Tecnicos);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel extrai a lista de tecnicos" });
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Tecnico>> TecnicoPorId(int id, [FromServices]LambadaContext context)
        {
            try
            {
                var tecnico = await context.Tecnico.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
                if (tecnico == null)
                {
                    return Ok(new { message = "Não existe nehum tecnico cadastrado com este nome" });
                }
                return Ok(tecnico);
                
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Não foi possivel extrair o tecnico " });
            }

        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Tecnico>>CadastraTecnico([FromBody]Tecnico model, [FromServices]LambadaContext context)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Dados do tecnico inavalido" });

            }
            else if (model.Sexo!=Sexo.Ferminino && model.Sexo!=Sexo.Masculino)
            {
                return BadRequest(new { message = "Sexo invalido" });
            }
            try
            {
                context.Add(model);
                await context.SaveChangesAsync();
                return Ok(new { message = "Tecnico cadastrado com sucesso" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel cadastrar o tecnico " });
            }
        }
        [Route("{id:int}")]
        [HttpPut]
        public async Task<ActionResult<Tecnico>>AtualizarTecnico([FromServices]LambadaContext context,[FromBody]Tecnico model, int id)
        {
            if (model.Id != id)
            {
                BadRequest(new { message = "Id informado invalido" });
            }
           else if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Objeto informado inválido" });
            }
            else if (model.Sexo != Sexo.Ferminino && model.Sexo != Sexo.Masculino)
            {
                return BadRequest(new { message = "Sexo informado inválido" });
            }
            try
            {
                context.Entry<Tecnico>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(new { message = "Dados alterados com sucesso" });
                
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel alterar o Tecnico" });
            }

        }
        [Route("{id:int}")]
        [HttpDelete]
        public async Task<ActionResult<Tecnico>>DeletarTecncio(int id, [FromServices]LambadaContext context)
        {
            var tecnico = await context.Tecnico.FirstOrDefaultAsync(x => x.Id == id);
            if (tecnico == null)
            {
                return BadRequest(new { message = "Tecnico não encontrado" });

            }
            try
            {
                context.Remove(tecnico);
                await context.SaveChangesAsync();
                return Ok(new { message = "Tecnico excluído com sucesso" });
            }
            catch (Exception)
            {
               return BadRequest(new { message = "Não foi possivel excluir o tecnico" });
            }
        }

        }
    }