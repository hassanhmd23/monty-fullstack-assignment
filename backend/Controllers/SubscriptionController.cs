using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Subscription;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        public SubscriptionController(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Subscription>>> GetAll()
        {
            var subscriptions = await _subscriptionRepository.GetAllSubscriptionsAsync();
            return Ok(subscriptions.Select(Subscription => Subscription.ToSubscriptionDto()));
        }

        [HttpGet("{subscriptionId:int}")]
        public async Task<ActionResult<Subscription>> GetById([FromRoute] int subscriptionId)
        {
            var subscription = await _subscriptionRepository.GetSubscriptionByIdAsync(subscriptionId);
            if (subscription == null)
            {
                return NotFound();
            }
            return Ok(subscription.ToSubscriptionDto());
        }

        [HttpPost]
        public async Task<ActionResult<Subscription>> Create([FromBody] CreateSubscriptionRequestDto createRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscription = createRequestDto.ToSubscriptionFromCreateDto();

            Console.WriteLine(subscription.StartDate);

            await _subscriptionRepository.CreateSubscriptionAsync(subscription);

            return CreatedAtAction(nameof(GetById), new { subscriptionId = subscription.Id }, subscription.ToSubscriptionDto());

        }

        [HttpPut("{subscriptionId:int}")]
        public async Task<ActionResult> Update([FromRoute] int subscriptionId, [FromBody] UpdateSubscriptionRequestDto updateRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscription = await _subscriptionRepository.UpdateSubscriptionAsync(subscriptionId, updateRequestDto);

            if (subscription == null)
            {
                return NotFound();
            }

            return Ok(subscription.ToSubscriptionDto());
        }

        [HttpDelete("{subscriptionId:int}")]
        public async Task<ActionResult> Delete([FromRoute] int subscriptionId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var subscription = await _subscriptionRepository.DeleteSubscriptionAsync(subscriptionId);

            if (subscription == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}