using System.Collections.Generic;
using AutoPeda.Models;

namespace AutoPeda.Data
{
    public interface IAutoPedaRepo
    {
        bool SaveChanges();

        IEnumerable<Auto> GetAllAutomobili();
        Auto GetAutoById(int id);
        void CreateAuto(Auto auto);
        void UpdateAuto(Auto auto);
        void DeleteAuto(Auto auto);

        IEnumerable<Korisnik> GetAllKorisnici();
        Korisnik GetKorisnikById(int id);
        void CreateKorisnik(Korisnik korisnik);
        void UpdateKorisnik(Korisnik korisnik);
        void DeleteKorisnik(Korisnik korisnik);

        IEnumerable<AutoMotor> GetAllAutoMotor();
        IEnumerable<AutoMotor> GetAutoMotorByAutoId(int id);
        AutoMotor GetAutoMotorById(int AutoId,int MotorId);
        void CreateAutoMotor(AutoMotor autoMotor);
        void UpdateAutoMotor(AutoMotor autoMotor);
        void DeleteAutoMotor(AutoMotor autoMotor);

        IEnumerable<Marka> GetAllMarka();
        Marka GetMarkaById(string naziv);
        void CreateMarka(Marka marka);
        void UpdateMarka(Marka marka);
        void DeleteMarka(Marka marka);

        IEnumerable<Model> GetAllModel();
        Model GetModelById(int id);
        void CreateModel(Model model);
        void UpdateModel(Model model);
        void DeleteModel(Model model);
        IEnumerable<Model> getModelForMarka(string id);
        IEnumerable<Model> getModelByName(string name, string marka);

        IEnumerable<Motor> GetAllMotor();
        Motor GetMotorById(int id);
        void CreateMotor(Motor motor);
        void UpdateMotor(Motor motor);
        void DeleteMotor(Motor motor);

        IEnumerable<Narudzbina> GetAllNarudzbina();
        Narudzbina GetNarudzbinaById(int id);
        void CreateNarudzbina(Narudzbina narudzbina);
        void UpdateNarudzbina(Narudzbina narudzbina);
        void DeleteNarudzbina(Narudzbina narudzbina);

        IEnumerable<Proizvod> GetAllProizvod();
        Proizvod GetProizvodById(int id);
        void CreateProizvod(Proizvod proizvod);
        void UpdateProizvod(Proizvod proizvod);
        void DeleteProizvod(Proizvod proizvod);

        IEnumerable<Slika> GetAllSlika();
        IEnumerable<Slika> GetSlikaByProizvodId(int id);
        void CreateSlika(Slika slika);
        void UpdateSlika(Slika slika);
        void DeleteSlika(Slika slika);

        IEnumerable<KategorijaProizvoda> GetAllKategorije();


        IEnumerable<PotkategorijaProizvoda> GetAllPotkategorije();
    }
}