# Blazor TODO

This is a simple project just to try out blazor and learn a bit about it.

It's interesting how static variable replicate through different clients, how services can retain data accros pages or not and specially awesome that running serverside blazor might allow you to connect to the database directly and avoid bleeding sensitive information to client side.

It's also nice to point out the CSS scoping, unfortunatelly it doesn't work with SCSS but it's quite awesome. Reminds a bit of Angular. It's not perfect though, you can see that when using some of the built-in function for FORMS I had to use some global CSS to style the error messages since the `::deep` keyword they advise to use in the docs really was not working T-T

## Running

Just run `dotnet run`.

## Example

![](./example.png)