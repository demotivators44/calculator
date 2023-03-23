namespace Weather.WebApi
{
	public class TokenMiddleware
	{
		private readonly RequestDelegate _next;

		public TokenMiddleware(RequestDelegate next)
		{
			this._next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			var token = context.Request.Query["token"];
			if (token != "12345678")
			{
				context.Response.StatusCode = 403;
				await context.Response.WriteAsync("Token is invalid");
			}
			else
			{
				await _next.Invoke(context);
			}
		}
	}

	public class TokenMiddleware2
	{
		private readonly RequestDelegate _next;
		string pattern;
		public TokenMiddleware2(RequestDelegate next, string pattern)
		{
			this._next = next;
			this.pattern = pattern;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			var token = context.Request.Query["token"];
			if (token != pattern)
			{
				context.Response.StatusCode = 403;
				await context.Response.WriteAsync("Token is invalid");
			}
			else
			{
				await _next.Invoke(context);
			}
		}
	}
}
