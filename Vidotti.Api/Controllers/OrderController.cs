﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidotti.Domain.Commands.Handlers;
using Vidotti.Domain.Commands.Inputs;
using Vidotti.Infra.Transactions;

namespace Vidotti.Api.Controllers
{
    public class OrderController : BaseController
    {
        private readonly OrderCommandHandler _handler;
        public OrderController(IUow uow, OrderCommandHandler handler) : base(uow)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/orders")]
        public async Task<IActionResult> Post([FromBody]RegisterOrderCommand command)
        {
            var result = _handler.Handle(command);
            return await ResponseAsync(result, _handler.Notifications);
        }
    }
}
