using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luceed.Model
{
    public class Article
    {
        public int Id { get; set; }
        public int Sid { get; set; }
        public string ArtiklUid { get; set; }
        public object ArtiklB2b { get; set; }
        public string Artikl { get; set; }
        public string Naziv { get; set; }
        public object NazivKratki { get; set; }
        public object Barcode { get; set; }
        public string Jm { get; set; }
        public object Opis { get; set; }
        public object Pakiranje { get; set; }
        public object PakiranjeJm { get; set; }
        public object PakiranjeTrans { get; set; }
        public object PakiranjeTransJm { get; set; }
        public double Vpc { get; set; }
        public object Mpc { get; set; }
        public string Enabled { get; set; }
        public string Usluga { get; set; }
        public string Materijal { get; set; }
        public string Eol { get; set; }
        public string Multipack { get; set; }
        public string TrgovackaRoba { get; set; }
        public object Duzina { get; set; }
        public object Sirina { get; set; }
        public object Visina { get; set; }
        public string Bundle { get; set; }
        public string Webshop { get; set; }
        public object Specifikacija { get; set; }
        public object KataloskiBroj { get; set; }
        public object Masa { get; set; }
        public object Volumen { get; set; }
        public int KolicinaMinProdaja { get; set; }
        public object PakiranjeMasa { get; set; }
        public object PakiranjeTransMasa { get; set; }
        public object PakiranjeBarcode { get; set; }
        public object PakiranjeTransBarcode { get; set; }
        public object PakiranjeTransDuzina { get; set; }
        public object PakiranjeTransSirina { get; set; }
        public object PakiranjeTransVisina { get; set; }
        public object Deklaracija { get; set; }
        public object Redoslijed { get; set; }
        public string Varijante { get; set; }
        public object Upozorenje { get; set; }
        public string PoreznaTarifaUid { get; set; }
        public object PoreznaTarifaB2b { get; set; }
        public string PoreznaTarifa { get; set; }
        public string PoreznaTarifaNaziv { get; set; }
        public int StopaPdv { get; set; }
        public int StopaPp { get; set; }
        public int AmbalaznaNaknada { get; set; }
        public object SupergrupaArtikla { get; set; }
        public object SupergrupaArtiklaNaziv { get; set; }
        public string NadgrupaArtikla { get; set; }
        public string NadgrupaArtiklaNaziv { get; set; }
        public string GrupaArtiklaUid { get; set; }
        public string GrupaArtikla { get; set; }
        public string GrupaArtiklaNaziv { get; set; }
        public object RobnaMarkaUid { get; set; }
        public object RobnaMarka { get; set; }
        public object RobnaMarkaNaziv { get; set; }
        public object RobnaMarkaB2b { get; set; }
        public object SpolUid { get; set; }
        public object SpolB2b { get; set; }
        public object Spol { get; set; }
        public object SpolNaziv { get; set; }
        public object MarkerUid { get; set; }
        public object MarkerB2b { get; set; }
        public object Marker { get; set; }
        public object MarkerNaziv { get; set; }
        public object VelicinaUid { get; set; }
        public object VelicinaB2b { get; set; }
        public object Velicina { get; set; }
        public object VelicinaNaziv { get; set; }
        public object BojaUid { get; set; }
        public object BojaB2b { get; set; }
        public object Boja { get; set; }
        public object BojaNaziv { get; set; }
        public object SezonaUid { get; set; }
        public object SezonaB2b { get; set; }
        public object Sezona { get; set; }
        public object SezonaNaziv { get; set; }
        public object JamstvoUid { get; set; }
        public object JamstvoB2b { get; set; }
        public object Jamstvo { get; set; }
        public object JamstvoNaziv { get; set; }
        public object KolekcijaUid { get; set; }
        public object KolekcijaB2b { get; set; }
        public object Kolekcija { get; set; }
        public object KolekcijaNaziv { get; set; }
        public object LicencaUid { get; set; }
        public object LicencaB2b { get; set; }
        public object Licenca { get; set; }
        public object LicencaNaziv { get; set; }
        public object VarijantaUid { get; set; }
        public object VarijantaB2b { get; set; }
        public object Varijanta { get; set; }
        public object VarijantaNaziv { get; set; }
        public object PredmetUid { get; set; }
        public object PredmetB2b { get; set; }
        public object Predmet { get; set; }
        public object PredmetNaziv { get; set; }
        public object OsnovniArtiklUid { get; set; }
        public object OsnovniArtiklB2b { get; set; }
        public object OsnovniArtikl { get; set; }
        public object OsnovniArtiklNaziv { get; set; }
        public object ReferentnaVelicinaUid { get; set; }
        public object ReferentnaVelicinaB2b { get; set; }
        public object ReferentnaVelicina { get; set; }
        public object PorijekloDrzavaUid { get; set; }
        public object PorijekloDrzavaB2b { get; set; }
        public object PorijekloDrzava { get; set; }
        public object PorijekloDrzavaNaziv { get; set; }
        public object CarinskaTarifaUid { get; set; }
        public object CarinskaTarifaB2b { get; set; }
        public object CarinskaTarifa { get; set; }
        public object CarinskaTarifaNaziv { get; set; }
        public double MpcPrvi { get; set; }
        public object StanjeKol { get; set; }
        public object RaspolozivoKol { get; set; }
        public string Stanje { get; set; }
        public string Raspolozivo { get; set; }
        public List<object> Atributi { get; set; }
        public List<object> Dokumenti { get; set; }
        public List<object> Jezici { get; set; }

    }
}
