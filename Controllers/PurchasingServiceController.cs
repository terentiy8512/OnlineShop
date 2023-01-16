using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Assignment2.Data;
using Assignment2.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api")]
[ApiController]
public class PurchasingServiceController : Controller
{
    private readonly IWebAPIRepo _repository;

    public PurchasingServiceController(IWebAPIRepo repository)
    {
        _repository = repository;
    }

    [HttpPost("Register")]
    public ActionResult Register(Users user)
    {
        if (_repository.UserExistOrNot(user))
            return Ok("Username not available.");

        _repository.AddUser(user);
        return Ok("User successfully registered.");
    }

    [HttpGet("GetVersionA")]
    [Authorize(AuthenticationSchemes = "UserAuthentication")]
    [Authorize(Policy = "UserOnly")]
    public ActionResult<string> GetVersionA()
    {
        return Ok("v1");
    }

    [HttpPost("PurchaseItem")]
    [Authorize(AuthenticationSchemes = "UserAuthentication")]
    [Authorize(Policy = "UserOnly")]
    public ActionResult<Orders> PurchaseItem(OrdersDto ordersDto)
    {
        ClaimsIdentity ci = HttpContext.User.Identities.FirstOrDefault();
        Claim c = ci.FindFirst("userName");
        string username = c.Value;
        Orders order = new Orders { ProductId = ordersDto.ProductId, UserName = username, Quantity = ordersDto.Quantity };
        Orders orderWithId = _repository.AddOrder(order);
        return CreatedAtAction(nameof(GetOrder), new { id = orderWithId.Id }, orderWithId);
    }

    [HttpGet("GetOrder/{ID}")]
    public ActionResult<Orders> GetOrder(int id)
    {
        Orders order = _repository.GetOrder(id);
        if (order == null)
            return NotFound();
        return Ok(order);
    }

    [HttpGet("PurchaseSingleItem/{ID}")]
    [Authorize(AuthenticationSchemes = "UserAuthentication")]
    [Authorize(Policy = "UserOnly")]
    public ActionResult<Orders> PurchaseSingleItem(int id)
    {
        ClaimsIdentity ci = HttpContext.User.Identities.FirstOrDefault();
        Claim c = ci.FindFirst("userName");
        string username = c.Value;
        Orders order = new Orders { ProductId = id, UserName = username, Quantity = 1 };
        Orders orderWithId = _repository.AddOrder(order);
        return CreatedAtAction(nameof(GetOrder), new { id = orderWithId.Id }, orderWithId);
    }
}


