using Data.Entities;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FragranceShopApi
{
    public class PerfumesShopDbSeeder
    {
        private readonly PerfumeDbContext _dbContext;
        public PerfumesShopDbSeeder(PerfumeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                SeedRoles();
            }
        }

        private void SeedPerfumers()
        {
            if (!_dbContext.Perfumers.Any())
            {
                var perfumers = GetPerfumers();
                _dbContext.Perfumers.AddRange(perfumers);

                _dbContext.SaveChanges();
            }
        }

        private void SeedRoles()
        {
            if (!_dbContext.Roles.Any())
            {
                var roles = GetRoles();
                _dbContext.Roles.AddRange(roles);

                _dbContext.SaveChanges();
            }
        }

        private void SeedPerfumeBrands()
        {
            if (!_dbContext.PerfumeBrands.Any())
            {
                var perfumeBrands = GetPerfumeBrands();
                _dbContext.PerfumeBrands.AddRange(perfumeBrands);

                _dbContext.SaveChanges();
            }
        }

        private void SeedPerfumes()
        {
            if (!_dbContext.Perfumes.Any())
            {
                var perfumes = GetPerfumes();
                _dbContext.Perfumes.AddRange(perfumes);

                _dbContext.SaveChanges();
            }  
        }

        private void SeedFragranceNotes()
        {
            if (!_dbContext.FragranceNotes.Any())
            {
                var fragranceNotes = GetFragranceNotes();
                _dbContext.FragranceNotes.AddRange(fragranceNotes);

                _dbContext.SaveChanges();
            }
        }

        private void SeedFragranceNotesToPerfume()
        {
            if (!_dbContext.FragranceNotesPerfumes.Any())
            {
                var perfumesFragranceNotes = GetPerfumeFragranceNotes();
                _dbContext.FragranceNotesPerfumes.AddRange(perfumesFragranceNotes);

                _dbContext.SaveChanges();
            }
        }

        private IEnumerable<FragranceNotePerfume> GetPerfumeFragranceNotes()
        {
            var perfumesFragrances = new List<FragranceNotePerfume>
            {
                new FragranceNotePerfume
                {
                    PerfumeId = _dbContext.Perfumes.First(x => x.Name == "Encre Noire").Id,
                    FragranceNoteId = _dbContext.FragranceNotes.First().Id
                }
            };

            return perfumesFragrances;
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Admin"
                },
                new Role()
                {
                    Name = "ProductsAdmin"
                }
            };

            return roles;
        }

        private IEnumerable<PerfumeBrand> GetPerfumeBrands()
        {
            var roles = new List<PerfumeBrand>()
            {
                new PerfumeBrand()
                {
                    Name = "Chanel"
                },
                new PerfumeBrand()
                {
                    Name = "Lalique"
                },
                new PerfumeBrand()
                {
                    Name = "Bentley"
                }
            };

            return roles;
        }

        private IEnumerable<Perfume> GetPerfumes()
        {
            var perfumes = new List<Perfume>()
            {
                new Perfume()
                {
                    Name = "Encre Noire",
                    PerfumerId = _dbContext.Perfumers.First(p => p.Name == "Nathalie Lorson").Id,
                    CurrentPrice = 110,
                    BasePrice = 110,
                    Quantity = 1,
                    PerfumeBrandId = _dbContext.PerfumeBrands.First(p => p.Name == "Lalique").Id,
                    Capacity = 100,
                    PerfumeGenderTypeId = PerfumeGenderTypeId.ForMen,
                    Year = 2020
                },
                new Perfume()
                {
                    Name = "Bentley for Men Intense",
                    PerfumerId = _dbContext.Perfumers.First(p => p.Name == "Nathalie Lorson").Id,
                    CurrentPrice = 130,
                    BasePrice = 200,
                    Quantity = 1,
                    PerfumeBrandId = _dbContext.PerfumeBrands.First(p => p.Name == "Bentley").Id,
                    Capacity = 100,
                    PerfumeGenderTypeId = PerfumeGenderTypeId.ForMen,
                    Year = 2020
                },
                new Perfume()
                {
                    Name = "Bentley for Men Intense",
                    PerfumerId = _dbContext.Perfumers.First(p => p.Name == "Nathalie Lorson").Id,
                    CurrentPrice = 100,
                    BasePrice = 100,
                    Quantity = 1,
                    PerfumeBrandId = _dbContext.PerfumeBrands.First(p => p.Name == "Bentley").Id,
                    Capacity = 50,
                    PerfumeGenderTypeId = PerfumeGenderTypeId.ForMen,
                    Year = 2020
                },
                new Perfume()
                {
                    Name = "Bentley for Men Intense",
                    PerfumerId = _dbContext.Perfumers.First(p => p.Name == "Nathalie Lorson").Id,
                    CurrentPrice = 100,
                    BasePrice = 100,
                    Quantity = 1,
                    PerfumeBrandId = _dbContext.PerfumeBrands.First(p => p.Name == "Bentley").Id,
                    Capacity = 100,
                    PerfumeGenderTypeId = PerfumeGenderTypeId.ForMen,
                    Year = 2020
                },
                new Perfume()
                {
                    Name = "Bentley for Men Intense",
                    PerfumerId = _dbContext.Perfumers.First(p => p.Name == "Nathalie Lorson").Id,
                    CurrentPrice = 100,
                    BasePrice = 100,
                    Quantity = 1,
                    PerfumeBrandId = _dbContext.PerfumeBrands.First(p => p.Name == "Bentley").Id,
                    Capacity = 100,
                    PerfumeGenderTypeId = PerfumeGenderTypeId.ForMen,
                    Year = 2020
                },
                new Perfume()
                {
                    Name = "Bentley for Men Intense",
                    PerfumerId = _dbContext.Perfumers.First(p => p.Name == "Nathalie Lorson").Id,
                    CurrentPrice = 100,
                    BasePrice = 200,
                    Quantity = 1,
                    PerfumeBrandId = _dbContext.PerfumeBrands.First(p => p.Name == "Bentley").Id,
                    Capacity = 100,
                    PerfumeGenderTypeId = PerfumeGenderTypeId.ForMen,
                    Year = 2020
                },
                new Perfume()
                {
                    Name = "Bentley for Men Intense",
                    PerfumerId = _dbContext.Perfumers.First(p => p.Name == "Nathalie Lorson").Id,
                    CurrentPrice = 100,
                    BasePrice = 100,
                    Quantity = 1,
                    PerfumeBrandId = _dbContext.PerfumeBrands.First(p => p.Name == "Bentley").Id,
                    Capacity = 100,
                    PerfumeGenderTypeId = PerfumeGenderTypeId.ForMen,
                    Year = 2020
                },
                new Perfume()
                {
                    Name = "Bentley for Men Intense",
                    PerfumerId = _dbContext.Perfumers.First(p => p.Name == "Nathalie Lorson").Id,
                    CurrentPrice = 100,
                    BasePrice = 100,
                    Quantity = 1,
                    PerfumeBrandId = _dbContext.PerfumeBrands.First(p => p.Name == "Bentley").Id,
                    Capacity = 100,
                    PerfumeGenderTypeId = PerfumeGenderTypeId.ForMen,
                    Year = 2020
                },
                new Perfume()
                {
                    Name = "Bentley for Men Intense",
                    PerfumerId = _dbContext.Perfumers.First(p => p.Name == "Nathalie Lorson").Id,
                    CurrentPrice = 100,
                    BasePrice = 100,
                    Quantity = 1,
                    PerfumeBrandId = _dbContext.PerfumeBrands.First(p => p.Name == "Bentley").Id,
                    Capacity = 100,
                    PerfumeGenderTypeId = PerfumeGenderTypeId.ForMen,
                    Year = 2020
                },
                new Perfume()
                {
                    Name = "Bentley for Men Intense",
                    PerfumerId = _dbContext.Perfumers.First(p => p.Name == "Nathalie Lorson").Id,
                    CurrentPrice = 100,
                    BasePrice = 100,
                    Quantity = 1,
                    PerfumeBrandId = _dbContext.PerfumeBrands.First(p => p.Name == "Bentley").Id,
                    Capacity = 100,
                    PerfumeGenderTypeId = PerfumeGenderTypeId.ForMen,
                    Year = 2020
                }

            };

            return perfumes;
        }

        private IEnumerable<Perfumer> GetPerfumers()
        {
            var perfumers = new List<Perfumer>()
            {
                new Perfumer()
                {
                    Name = "Nathalie Lorson"
                },
                new Perfumer()
                {
                    Name = "Jacques Polge"
                }
            };

            return perfumers;
        }

        private IEnumerable<FragranceNote> GetFragranceNotes()
        {
            var fragranceNotes = new List<FragranceNote>()
            {
                new FragranceNote()
                {
                    Name = "Paczula"
                },
                new FragranceNote()
                {
                    Name = "Mandarynka"
                }
            };

            return fragranceNotes;
        }
    }
}
