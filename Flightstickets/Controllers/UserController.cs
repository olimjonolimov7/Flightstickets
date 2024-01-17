﻿using Flightstickets.Models;
using Flightstickets.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAllUsers()
    {
        try
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{userId}")]
    public ActionResult<User> GetUserById(int userId)
    {
        try
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
                return NotFound();

            return Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public ActionResult<User> AddUser([FromBody] User user)
    {
        try
        {
            _userService.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new { userId = user.UserId }, user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{userId}")]
    public IActionResult UpdateUser(int userId, [FromBody] User user)
    {
        try
        {
            var existingUser = _userService.GetUserById(userId);
            if (existingUser == null)
                return NotFound();

            user.UserId = userId;
            _userService.UpdateUser(user);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        try
        {
            var existingUser = _userService.GetUserById(userId);
            if (existingUser == null)
                return NotFound();

            _userService.DeleteUser(userId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
