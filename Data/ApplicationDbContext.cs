using AutoMapper.Configuration;
using capstone.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace capstone.Data
{

    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public IConfiguration Configuration { get; }
        public DbSet<MovieInfo> MovieInfos {get; set; }
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }
        public ApplicationDbContext() : base(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite("Data Source=app.db").Options,null)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<MovieInfo>()
                .HasData(
                    new MovieInfo {Id = 1, Title = "Transformers", Director = "Michael Bay", MainCatergory = "Action-Mess", UserRating = 2 },
                    new MovieInfo {Id = 2, Title = "Endgame", Director = "Rosso Brothers", MainCatergory = "SuperHero", UserRating = 5 },
                    new MovieInfo {Id = 3, Title = "Sleepless in Seattle", Director = "Nora Ephron", MainCatergory = "Romantic Comedy", UserRating = 4}
                );
            base.OnModelCreating(builder);
        }
    }
}
