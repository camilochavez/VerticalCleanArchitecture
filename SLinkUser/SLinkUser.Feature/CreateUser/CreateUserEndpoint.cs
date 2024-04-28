using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLinkUser.Feature.CreateUser
{
    public static class CreateUserEndpoint
    {
        public static void AddEndpoint(this IEndpointRouteBuilder app)
        {

            app.MapPost("api/books", async (CreateBookRequest request, ISender sender) =>
            {
                var bookId = await sender.Send(request);
                return Results.Ok(bookId);
            });
        }
    }
}
