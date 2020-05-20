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
    [Route("Lambada")]

    public class LambadaController : Controller
    {
        [Route("")]
        [HttpGet]
        public async Task<ActionResult<List<Lambada>>> Listadelamabda([FromServices]LambadaContext context)
        {
            try
            {
                var Lambadas = await context.Lambada.Include(x => x.Tecnico).AsNoTracking().ToListAsync();
                return Lambadas;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel trazer a lista de lambadas" });
            }


        }
        [Route("{id:int}")]
        [HttpGet]
        public async Task<ActionResult<Lambada>> LambadaPorId(int id, [FromServices]LambadaContext context)
        {
            try
            {
                var lambada = await context.Lambada.Include(x => x.Tecnico).AsNoTracking().ToListAsync();
                if (lambada == null)
                {
                    return Ok(new { message = "Nenhuma lambada encontrada com este id" });
                }
                return Ok(lambada);

            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel buscar a lambada" });
            }

        }
        [Route("Tecnico/{id:int}")]
        [HttpGet]
        public async Task<ActionResult<List<Lambada>>> LambadaPorTecncico(int id, [FromServices]LambadaContext context)
        {
            try
            {
                var Lambadas = await context.Lambada.Include(x => x.Tecnico).AsNoTracking().Where(x => x.TecnicoId == id).ToListAsync();
                if (Lambadas == null)
                {
                    return Ok(new { message = "Nenhuma lambada encontrada para este tecnico" });
                }
                return Ok(Lambadas);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel extrair a lista de lambadas por tecnico" });
            }

        }
        [Route("")]
        [HttpPost]
      

        public async Task<ActionResult<Lambada>> CadastroLambada([FromServices]LambadaContext context, [FromBody]Lambada model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Objecto inválido" });
            }
            try
            {
                context.Add(model);
                await context.SaveChangesAsync();
                return Ok(new { message = "Lambada registrada com sucesso" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel regsitrar lambada " });

            }

        }
        [Route("{id:int}")]
        [HttpPut]
        
        public async Task<ActionResult<Lambada>> AlterarLambada(int id, [FromServices]LambadaContext context, [FromBody]Lambada model)
        {
            if (model.Id != id)
            {
               return BadRequest(new { message = "Lambada digitada incorretamente" });
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Objecto inaválido" });
               
            }
            try
            {
                context.Entry<Lambada>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok (new { message = "Lambada atualizada com sucesso" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Não fooi possivel atualizar a lambada " });
            }

        }
        [Route("{id:int}")]
        [HttpDelete]
        public async Task<ActionResult<Lambada>>DeletaLambada(int id, [FromServices]LambadaContext context)
        {
            try
            {
                var lambada = await context.Lambada.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (lambada == null)
                {
                    return Ok(new { message = "Lambada não encontrada" });

                }
                context.Remove(lambada);
               await context.SaveChangesAsync();
                return Ok(new { message = "Lambada excluída com sucesso" });
            }
            catch (Exception)
            {
               return BadRequest(new { message = "Não foi possivel excluir a lambada" });
            }

        }

    }
}