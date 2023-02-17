using Microsoft.AspNetCore.Mvc;

namespace testapi.Controllers
{
    public class TestController : Controller
    {
        private static List<testmodel> employ = new List<testmodel>
            {
                new testmodel
                {
                    id= 1,
                    name="xyz",
                    description="testing"
                }
            };

        private readonly DataContext _context;

        public TestController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("testget")]
        public async Task<ActionResult<List<testmodel>>> Get()
        {
            //return employ;
            return await _context.empl.ToListAsync();

        }

        [HttpGet("testget/{id}")]
        public async Task<ActionResult<List<testmodel>>> Get(int id,string name)
        {
            /*
            var em = employ.Find(x => x.id == id);
            if (em == null)
                return BadRequest("employ not found");
            return Ok(em);
            */

            var em = await _context.empl.FindAsync(id);
            if (em == null)
                return BadRequest("employ not found");
            return Ok(em);


        }

        [HttpPost("testpost")]
        public async Task<ActionResult<List<testmodel>>> Post(testmodel emp)
        {
            /*
            employ.Add(emp);
            return employ;
            */

            _context.empl.Add(emp);
            await _context.SaveChangesAsync();

            return await _context.empl.ToListAsync();

        }

        [HttpPut("testput")]
        public async Task<ActionResult<List<testmodel>>> Put(testmodel edit)
        {
            /*var em = employ.Find(x => x.id == edit.id);
            if (em == null)
                return BadRequest("employ not found");

            em.name = edit.name;
            em.description = edit.description;

            //return Ok(em);
            return employ;*/

            var em = await _context.empl.FindAsync(edit.id);
            if (em == null)
                return BadRequest("employ not found");

            em.name = edit.name;
            em.description = edit.description;

            await _context.SaveChangesAsync();
            //return Ok(em);
            return Ok(await _context.empl.ToListAsync());

        }

        [HttpDelete("testdelete")]
        public async Task<ActionResult<List<testmodel>>> Delete(int id)
        {
            /*var em = employ.Find(h => h.id == id);
            if (em == null)
                return BadRequest("employ not found");
            employ.Remove(em);
            return employ;*/

            var em = await _context.empl.FindAsync(id);
            if (em == null)
                return BadRequest("employ not found");

            _context.empl.Remove(em);
            await _context.SaveChangesAsync();

            return await _context.empl.ToListAsync();
        }
    }
}