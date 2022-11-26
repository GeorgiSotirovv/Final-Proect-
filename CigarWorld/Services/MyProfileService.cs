using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Models.AddModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CigarWorld.Services
{
    public class MyProfileService : IMyProfileService
    {
        private readonly CigarWorldDbContext context;

        public MyProfileService(CigarWorldDbContext _context)
        {
            context = _context;
        }


        public FavoriteProductsViewModels GetAllFavoriteProductsViewModels(string userId)
        {
            var humidorService = new HumidorService(context);
            var ashtrayService = new AshtrayService(context);
            var cigarService = new CigarService(context);
            var cigarilloService = new CigarilloService(context);
            
            var lighterService = new LighterService(context);
            var cutterService = new CutterService(context);
            var cigarPoketCsaeService = new CigarCaseService(context);

            return new FavoriteProductsViewModels
            {
                FavoriteHumidor = humidorService.GetMineHumidorsAsync(userId).Result,
                FavoriteAshtray = ashtrayService.GetMineAshtrayAsync(userId).Result,
                FavoriteCigar = cigarService.GetMineCigarsAsync(userId).Result,
                FavoriteCigarillo = cigarilloService.GetMineCigarillosAsync(userId).Result,
                
                FavoriteLighter = lighterService.GetMineLightersAsync(userId).Result,
                FavoriteCutter = cutterService.GetMineCuttersAsync(userId).Result,
                FavoriteCigarPoketCase = cigarPoketCsaeService.GetMineCPCAsync(userId).Result
            };
        }
    }
}
