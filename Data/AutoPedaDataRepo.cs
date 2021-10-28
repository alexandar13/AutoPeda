using System;
using System.Collections.Generic;
using System.Linq;
using AutoPeda.Models;

namespace AutoPeda.Data
{
    public class AutoPedaDataRepo : IAutoPedaRepo
    {
        private readonly AutoPedaContext _context;


        public AutoPedaDataRepo(AutoPedaContext context)
        {
            _context=context;
        }


        public void CreateAuto(Auto auto)
        {
            if(auto==null)
            {
                throw new ArgumentNullException(nameof(auto));
            }

            _context.Automobili.Add(auto);
        }

        public void CreateAutoMotor(AutoMotor autoMotor)
        {
            if(autoMotor==null)
            {
                throw new ArgumentNullException(nameof(autoMotor));
            }

            _context.AutoMotor.Add(autoMotor);
        }

        public void CreateKorisnik(Korisnik korisnik)
        {
            if(korisnik==null)
            {
                throw new ArgumentNullException(nameof(korisnik));
            }

            _context.Korisnici.Add(korisnik);
        }

        public void CreateMarka(Marka marka)
        {
            if(marka==null)
            {
                throw new ArgumentNullException(nameof(marka));
            }

            _context.Marke.Add(marka);
        }

        public void CreateModel(Model model)
        {
            if(model==null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            _context.Modeli.Add(model);
        }

        public void CreateMotor(Motor motor)
        {
            if(motor==null)
            {
                throw new ArgumentNullException(nameof(motor));
            }

            _context.Motori.Add(motor);
        }

        public void CreateNarudzbina(Narudzbina narudzbina)
        {
            if(narudzbina==null)
            {
                throw new ArgumentNullException(nameof(narudzbina));
            }

            _context.Narudzbine.Add(narudzbina);
        }

        public void CreateProizvod(Proizvod proizvod)
        {
            if(proizvod==null)
            {
                throw new ArgumentNullException(nameof(proizvod));
            }

            _context.Proizvodi.Add(proizvod);
        }

        public void CreateSlika(Slika slika)
        {
            if(slika==null)
            {
                throw new ArgumentNullException(nameof(slika));
            }

            _context.Slike.Add(slika);
        }

        public void DeleteAuto(Auto auto)
        {
            if(auto==null)
            {
                throw new ArgumentNullException(nameof(auto));
            }

            _context.Automobili.Remove(auto);
        }

        public void DeleteAutoMotor(AutoMotor autoMotor)
        {
            if(autoMotor==null)
            {
                throw new ArgumentNullException(nameof(autoMotor));
            }

            _context.AutoMotor.Remove(autoMotor);
        }

        public void DeleteKorisnik(Korisnik korisnik)
        {
            if(korisnik==null)
            {
                throw new ArgumentNullException(nameof(korisnik));
            }

            _context.Korisnici.Remove(korisnik);
        }

        public void DeleteMarka(Marka marka)
        {
            if(marka==null)
            {
                throw new ArgumentNullException(nameof(marka));
            }

            _context.Marke.Remove(marka);
        }

        public void DeleteModel(Model model)
        {
            if(model==null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            _context.Modeli.Remove(model);
        }


        public void DeleteMotor(Motor motor)
        {
            if(motor==null)
            {
                throw new ArgumentNullException(nameof(motor));
            }

            _context.Motori.Remove(motor);
        }

        public void DeleteNarudzbina(Narudzbina narudzbina)
        {
            if(narudzbina==null)
            {
                throw new ArgumentNullException(nameof(narudzbina));
            }

            _context.Narudzbine.Remove(narudzbina);
        }

        public void DeleteProizvod(Proizvod proizvod)
        {
            if(proizvod==null)
            {
                throw new ArgumentNullException(nameof(proizvod));
            }

            _context.Proizvodi.Remove(proizvod);
        }

        public void DeleteSlika(Slika slika)
        {
            if(slika==null)
            {
                throw new ArgumentNullException(nameof(slika));
            }

            _context.Slike.Remove(slika);
        }

        public IEnumerable<Auto> GetAllAutomobili()
        {
            return _context.Automobili.ToList();
        }

        public IEnumerable<AutoMotor> GetAllAutoMotor()
        {
            return _context.AutoMotor.ToList();
        }

        public IEnumerable<Korisnik> GetAllKorisnici()
        {
            return _context.Korisnici.ToList();
        }

        public IEnumerable<Marka> GetAllMarka()
        {
            return _context.Marke.ToList();
        }

        public IEnumerable<Model> GetAllModel()
        {
            return _context.Modeli.ToList();
        }

        public IEnumerable<Motor> GetAllMotor()
        {
            return _context.Motori.ToList();
        }

        public IEnumerable<Narudzbina> GetAllNarudzbina()
        {
            return _context.Narudzbine.ToList();
        }

        public IEnumerable<Proizvod> GetAllProizvod()
        {
            return _context.Proizvodi.ToList();
        }

        public IEnumerable<Slika> GetAllSlika()
        {
            return _context.Slike.ToList();
        }

        public Auto GetAutoById(int id)
        {
            return _context.Automobili.FirstOrDefault(p => p.Id == id);
        }

        public Korisnik GetKorisnikById(int id)
        {
            return _context.Korisnici.FirstOrDefault(p => p.Id == id);
        }

        public Marka GetMarkaById(string naziv)
        {
            return _context.Marke.FirstOrDefault(p => p.Naziv == naziv);
        }

        public Model GetModelById(int id)
        {
            return _context.Modeli.FirstOrDefault(p => p.Id == id);
        }

        public Motor GetMotorById(int id)
        {
            return _context.Motori.FirstOrDefault(p => p.Id == id);
        }

        public Narudzbina GetNarudzbinaById(int id)
        {
            return _context.Narudzbine.FirstOrDefault(p => p.Id == id);
        }

        public Proizvod GetProizvodById(int id)
        {
            return _context.Proizvodi.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Slika> GetSlikaByProizvodId(int id)
        {
            return _context.Slike.Where(p => p.ProizvodId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);

        }

        public void UpdateAuto(Auto auto)
        {
            if(auto==null)
            {
                throw new ArgumentNullException(nameof(auto));
            }

            _context.Automobili.Update(auto);
        }

        public void UpdateAutoMotor(AutoMotor autoMotor)
        {
            if(autoMotor==null)
            {
                throw new ArgumentNullException(nameof(autoMotor));
            }
        }

        public void UpdateKorisnik(Korisnik korisnik)
        {
            if(korisnik==null)
            {
                throw new ArgumentNullException(nameof(korisnik));
            }
        }

        public void UpdateMarka(Marka marka)
        {
            if(marka==null)
            {
                throw new ArgumentNullException(nameof(marka));
            }
        }

        public void UpdateModel(Model model)
        {
            if(model==null)
            {
                throw new ArgumentNullException(nameof(model));
            }
        }

        public void UpdateMotor(Motor motor)
        {
            if(motor==null)
            {
                throw new ArgumentNullException(nameof(motor));
            }

            _context.Motori.Update(motor);
        }

        public void UpdateNarudzbina(Narudzbina narudzbina)
        {
            if(narudzbina==null)
            {
                throw new ArgumentNullException(nameof(narudzbina));
            }
        }

        public void UpdateProizvod(Proizvod proizvod)
        {
            if(proizvod==null)
            {
                throw new ArgumentNullException(nameof(proizvod));
            }
        }

        public void UpdateSlika(Slika slika)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AutoMotor> GetAutoMotorByAutoId(int id)
        {
            return _context.AutoMotor.Where(am => am.AutoId == id);
        }

        public AutoMotor GetAutoMotorById(int AutoId, int MotorId)
        {
            return _context.AutoMotor.FirstOrDefault(am => (am.AutoId == AutoId && am.MotorId == MotorId));
        }

        public IEnumerable<Model> getModelForMarka(string marka)
        {
            return _context.Modeli.Where(m => m.MarkaId == marka).ToList();
        }

        public IEnumerable<Model> getModelByName(string name, string marka)
        {
            return _context.Modeli.Where(m => (m.Naziv == name && m.MarkaId == marka)).ToList();
        }

        public IEnumerable<KategorijaProizvoda> GetAllKategorije()
        {
            return _context.Kategorije;
        }

        public IEnumerable<PotkategorijaProizvoda> GetAllPotkategorije()
        {
            return _context.Potkategorije;
        }
    }
}