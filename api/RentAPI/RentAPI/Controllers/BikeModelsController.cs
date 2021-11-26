
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentAPI.Models;
using RentAPI.Interfaces;

namespace RentAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeModelsController : ControllerBase
    {
       
        private readonly IFindRent _findRent;
        private readonly IDelete _delete;
        private readonly ISave _save;
        private readonly IAdd _add;
        private readonly IList _list;
        private readonly IExist _exist;
        private readonly IEntry _entry;

        public BikeModelsController(IFindRent findRent, IDelete delete, ISave save, IAdd add, IList list, IExist exist , IEntry entry)
        {
           
            _findRent = findRent;
            _delete = delete;
            _save = save;
            _add = add;
            _list = list;
            _exist = exist;
            _entry = entry;
        }

        // GET: api/BikeModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BikeModel>>> GetBikeModel()
        {
            return await _list.GetList();
        }

        // PUT: api/BikeModels/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBikeModel(int id, BikeModel bikeModel)
        {
            if (id != bikeModel.Id)
            {
                return BadRequest();
            }

           _entry.Entry(bikeModel).State = EntityState.Modified;

            try
            {
               await _save.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_exist.BikeModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BikeModels
        [HttpPost]
        public async Task<ActionResult<BikeModel>> PostBikeModel(BikeModel bikeModel)
        {
            _add.Add(bikeModel);
            await _save.Save();

            return CreatedAtAction("GetBikeModel", new { id = bikeModel.Id }, bikeModel);
        }

        // DELETE: api/BikeModels/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBikeModel(int id)
        {
            var bikeModel = _findRent.FindRent(id);
            if (bikeModel == null)
            {
                return NotFound();
            }
            _delete.Delete(bikeModel);
            await _save.Save();

            return NoContent();
        }
    }
}
