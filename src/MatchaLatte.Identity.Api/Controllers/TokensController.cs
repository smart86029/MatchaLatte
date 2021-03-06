﻿using System.Threading.Tasks;
using MatchaLatte.Identity.App.Tokens;
using Microsoft.AspNetCore.Mvc;

namespace MatchaLatte.Identity.Api.Controllers
{
    /// <summary>
    /// 令牌控制器。
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly ITokenService tokenService;

        /// <summary>
        /// 初始化 <see cref="TokensController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="tokenService">令牌服務。</param>
        public TokensController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        /// <summary>
        /// 建立令牌。
        /// </summary>
        /// <param name="command">建立令牌命令。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> PostAsync([FromBody] CreateTokenCommand command)
        {
            var token = await tokenService.CreateTokenAsync(command);
            if (token == null)
                return BadRequest();

            return Ok(token);
        }

        /// <summary>
        /// 刷新令牌。
        /// </summary>
        /// <param name="command">刷新令牌命令。</param>
        /// <returns>201 Created。</returns>
        [HttpPost("refresh")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> PostAsync([FromBody] RefreshTokenCommand command)
        {
            var token = await tokenService.RefreshTokenAsync(command);
            if (token == null)
                return BadRequest();

            return Ok(token);
        }
    }
}