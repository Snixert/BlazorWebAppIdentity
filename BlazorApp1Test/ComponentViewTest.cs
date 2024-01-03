using BlazorApp1;
using BlazorApp1.Components.Pages;
using Bunit;
using Bunit.TestDoubles;
namespace BlazorApp1Test
{
    public class ComponentViewTest
    {
        [Fact]
        public void TestAuthorized()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("");


            // Act
            var cut = ctx.RenderComponent<Page3>();

            // Assert
            cut.MarkupMatches(@"<h3>Page 3</h3><div>Du er logget ind</div>");
        }

        [Fact]
        public void TestNotAuthorized()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetNotAuthorized();


            // Act
            var cut = ctx.RenderComponent<Page3>();

            // Assert
            cut.MarkupMatches(@"<h3>Page 3</h3><div>Du er ikke logget ind</div>");
        }

        [Fact]
        public void TestAdminAuthorization()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetRoles("Admin");


            // Act
            var cut = ctx.RenderComponent<Page2>();

            // Assert
            cut.MarkupMatches(@"<h3>Page 2</h3><div>Adgang tilladt fordi du er admin.</div>");
        }

        [Fact]
        public void TestAdminNoAuthorization()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetNotAuthorized();


            // Act
            var cut = ctx.RenderComponent<Page2>();

            // Assert
            cut.MarkupMatches(@"<h3>Page 2</h3><div>Adgang nægtet, du er IKKE admin.</div>");
        }

        [Fact]
        public void TestIsAuthenticated()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("");


            // Act
            var cut = ctx.RenderComponent<Page4>();
            var instance = cut.Instance;
            bool isAuthenticated = instance.IsAuthenticated;

            // Assert
            Assert.True(isAuthenticated);
        }

        [Fact]
        public void TestIsNotAuthenticated()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();


            // Act
            var cut = ctx.RenderComponent<Page4>();
            var instance = cut.Instance;
            bool isAuthenticated = instance.IsAuthenticated;

            // Assert
            Assert.False(isAuthenticated);
        }

        [Fact]
        public void TestUserIsAuthorized()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("");
            authContext.SetRoles("Admin");


            // Act
            var cut = ctx.RenderComponent<Page4>();
            var instance = cut.Instance;
            bool isAuthorized = instance.IsAuthorized;

            // Assert
            Assert.True(isAuthorized);
        }

        [Fact]
        public void TestUserIsNotAuthorized()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();


            // Act
            var cut = ctx.RenderComponent<Page4>();
            var instance = cut.Instance;
            bool isAuthorized = instance.IsAuthorized;

            // Assert
            Assert.False(isAuthorized);
        }

    }
}