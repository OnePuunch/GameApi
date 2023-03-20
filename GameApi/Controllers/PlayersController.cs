using GameApi.Models;
using GameApi.Services;
using GameApi.Tools;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService playerService;
        public PlayersController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        // GET: api/<PlayerController>
        [HttpGet]
        public ActionResult<List<Player>> Get()
        {
            return playerService.Get();
        }

        // GET api/<PlayerController>/5
        [HttpGet("{id}")]
        public ActionResult<Player> Get(string id)
        {
            var player = playerService.Get(id);

            return player != null ? player : NotFound($"Player with id = {id} not found");
        }

        // POST api/<PlayerController>
        [HttpPost]
        public ActionResult<Player> Post([FromBody] Player player)
        {
            playerService.Create(player);
            return CreatedAtAction(nameof(Get), new {id = player.Id }, player);
        }

        // PUT api/<PlayerController>/5
        [HttpPut("{id}")]
        public ActionResult<Player> Put(string id, [FromBody] Player playerUpdate)
        {
            var existingPlayer = playerService.Get(id);

            if (existingPlayer == null)
                return NotFound($"Player with id = {id} not found");

            ObjectUpdater.UpdateObject(existingPlayer, playerUpdate);

            playerService.Update(id, existingPlayer);

            return NoContent();
        }

        // DELETE api/<PlayerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingPlayer = playerService.Get(id);

            if (existingPlayer == null)
                return NotFound($"Player with id = {id} not found");

            playerService.Remove(id);

            return Ok($"Player with Id = {id} deleted.");
        }
    }
}
