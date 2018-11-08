using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace SignalRTest
{
    public class Startup
    {
		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSignalR();
			services.AddCors(options =>
			{
				options.AddPolicy("AllowAny", x => {
					x.AllowAnyHeader()
					.AllowAnyMethod()
					.AllowAnyOrigin();
				});
			});
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseCors("AllowAny");
			app.UseSignalR(routes =>
			{
				routes.MapHub<MessageHub>("/message");
			});
			app.UseMvc();
		}
	}
}
