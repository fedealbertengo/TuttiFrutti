using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPresentacion.Pantallas;

namespace CPresentacion
{
    public partial class PantallaInicio : Form
    {
        public PantallaInicio()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            IniciarSesion insec = new IniciarSesion();
            this.Hide();
            insec.Show(this);
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Registrarse reg = new Registrarse();
            this.Hide();
            reg.Show(this);
        }

        private void PantallaInicio_Load(object sender, EventArgs e)
        {
            /*
            try
            {

                CLogica.Gestores.GestorDePalabra clogPal = new CLogica.Gestores.GestorDePalabra();
                List<string> nombres = new List<string> { "Alejandro", "Alejo", "Alfonso", "Alfredo", "Alicia", "Alipio", "Almudena", "Alvaro", "Amadeo", "Amaro", "Ambrosio", "Amelia o Amalia", "Ana", "Ananías", "Anastasia", "Anatolio", "Andrés", "Ángel", "Anselmo", "Antero", "Antonio", "Aquiles", "Araceli", "Aránzazu", "Arcadio", "Aresio", "Ariadna", "Aristides", "Arnaldo", "Artemio", "Arturo", "Atanasio", "Augusto", "Áurea", "Aurelia", "Aureliano", "Aurelio", "Baldomero", "Balduino", "Baltasar", "Bárbara", "Bartolomé", "Basileo", "Beatriz", "Belén", "Beltrán", "Benedicto", "Benigno", "Benjamín", "Bernabé", "Bernardo", "Blanca", "Blas", "Bonifacio", "Bruno", "Calixto", "Camilo", "Cándida", "Carina", "Carlos", "Carmen", "Casiano", "Casimiro", "Casio", "Catalina", "Cayetano", "Cayo", "Cecilia", "Ceferino", "Celia", "Celso", "Cesáreo", "Cipriano", "Cirilo", "Cirino", "Ciro", "Claudio", "Cleofás", "Clotilde", "Colombo", "Columba", "Columbano", "Conrado", "Constancio", "Constantino", "Cosme", "Cristina", "Cristóbal", "Daciano", "Dacio", "Dámaso", "Damián", "Daniel", "Dario", "David", "Demócrito", "Diego", "Dimas", "Domingo", "Donato", "Dorotea", "Edmundo", "Eduardo", "Eduvigis", "Efrén", "Elena", "Elías", "Elisa", "Eliseo", "Emiliano", "Emilio", "Enrique", "Epifanía", "Erico", "Ernesto", "Esdras", "Esiquio", "Esteban", "Ester", "Eugenia", "Eulalia", "Eusebio", "Eva", "Evaristo", "Ezequiel", "Fabián", "Fabio", "Fabiola", "Facundo", "Faustino", "Fausto", "Federico", "Feliciano", "Felipe", "Félix", "Fermin", "Fernando", "Fidel", "Fortunato", "Francisco", "Fulgencio", "Gabriel", "Genoveva", "Gerardo", "Germán", "Gertrudis", "Gisela", "Godofredo", "Gonzalo", "Gregorio", "Guadalupe", "Guido", "Guillermo", "Guzmán", "Heliodoro", "Heraclio", "Heriberto", "Hilarión", "Hildegarda", "Homero", "Honorato", "Honorio", "Hugo", "Humberto", "Ifigenia", "Ignacio", "Ildefonso", "Inés", "Inmaculada", "Inocencio", "Irene", "Ireneo", "Isaac", "Isabel o Elisa", "Isaias", "Ismael", "Ivon", "Jacinto", "Jacob", "Jaime", "Javier", "Jeremías", "Jerónimo", "Jesús", "Joaquím", "Joel", "Jonás", "Jorge", "Josafat", "José", "Josué", "Juan", "Julián", "Justino", "Juvenal", "Ladislao", "Laura", "Laureano", "Lázaro", "Leandro", "Leocadia", "Leonardo", "Leoncio", "Leonor", "Leopoldo", "Lidia", "Liduvina", "Lino", "Lorenzo", "Lucano", "Lucas", "Lucía", "Luciano", "Lucrecia", "Luis", "Macario", "Magdalena", "Manuel", "Marcelino", "Marcelo", "Marcial", "Marciano", "Marcos", "Margarita", "María", "Mariano", "Marina", "Mario", "Marta", "Martín", "Mateo", "Matías", "Matilde", "Mauricio", "Maximiliano", "Melchor", "Mercedes", "Miguel", "Miqueas", "Moisés", "Mónica", "Montserrat", "Narciso", "Natalia", "Nazario", "Nemesio", "Nicanor", "Nicodemo", "Nicolás", "Nicomedes", "Nieves", "Noé", "Norberto", "Octavio", "Odón", "Onésimo", "Orestes", "Oriol", "Óscar", "Oseas", "Oswaldo", "Otilia", "Oto", "Pablo", "Pancracio", "Patricio", "Paula", "Pedro", "Petronila", "Pío", "Porfirio", "Ramón", "Rebeca", "Rogelio", "Roque", "Rosalia", "Rosario", "Rosendo", "Rufo", "Ruperto", "Salomé", "Salomón", "Salvador", "Salvio", "Samuel", "Sansón", "Santiago", "Sara", "Sebastián", "Segismundo", "Sergio", "Severino", "Simeón", "Simón", "Siro", "Sixto", "Sofía", "Susana", "Tadeo", "Tarsicio", "Teodora", "Teodosia", "Teófanes", "Teófila", "Teresa", "Timoteo", "Tito", "Tobías", "Tomás", "Toribio", "Ubaldo", "Urbano", "Ursula", "Valentín", "Valeriano", "Velerio", "Venancio", "Verónica", "Vicente", "Víctor", "Victorino", "Victorio", "Vidal", "Virgilio", "Vladimiro", "Wilfredo", "Zacarías", "Zaqueo" };
                List<string> animales = new List<string> { "Antilope", "Araña", "Anaconda", "Alce", "Armiño", "Avestruz", "Burro", "Borrego", "Babuino", "Bisonte", "Boa", "Cabra", "Cebra", "Cotorra", "Calamar", "Canario", "Chinchilla", "Cacatúa", "Castor", "Cangrejo", "Dromedario", "Delfin", "Dragón de komodo", "Elefante", "Escorpion", "Escarabajo", "Erizo", "Esponja", "Faisan", "Flamenco", "Farra", "Foca", "Guacamayo", "Gato", "Gorrion", "Gacela", "Golondrina", "Garza", "Hipopotamo", "Hormiga", "Hamster", "Hiena", "Halcón", "Ibis", "Iguana", "Impala", "Jaguar", "Jabali", "Jirafa", "Koala", "Kiwi", "Krill", "Leon", "Lagarto", "Lagartija", "Llama", "Lemur", "Liebre", "Lince", "Mangosta", "Mono", "Marmota", "Mosca", "Mandril", "Manatí", "Morsa", "Nutria", "Nauyaca(serpiente)", "Ñandu", "Ñu", "Ornitorrinco", "Oso", "Oveja", "Ocelote", "Orca", "Pez", "Paloma", "Perro", "Pato", "Pelícano", "Pingüino", "Quetzal", "Quirquincho", "Quitón", "Rinoceronte", "Raton", "Rana", "Reno", "Raya", "Serpiente", "Sardina", "Salmon", "Sapo", "Salamandra", "Saltamontes", "Suricata", "Tigre", "Toro", "Tiburon", "Tortuga", "Tejón", "Topo", "Tucán", "Urogallo", "Uro", "Urraca", "Uapití", "Vicuña", "Vaca", "Venado", "Vizcacha", "Walabi", "Wombat", "Xantus", "Xoloizcuintle(es un perro mexicano)", "Yak", "Yaguarete", "Yegua", "Zarigüeya", "Zorro" };
                List<string> colores = new List<string> { "Azul", "Amarillo", "Ámbar", "Añil", "Aguamarina", "Amatista", "Avellana", "Aceitunado", "Albaricoque", "Arlequín", "Amaranto", "Azur", "Bermellón", "Blanco", "Beige", "Burdeo", "Betamina", "Bronceado", "Borgoña", "BistreIndigo", "Celeste", "Colorado", "Café", "Caramelo", "Ciano", "Castaño", "Coral", "Carmín", "Carmesí", "Canela", "Cenizo", "Cerúleo", "Champagne", "Champán", "Chocolate", "Cacao", "Crema", "Cardo", "Ciruela", "Dorado", "Durazno", "Denim", "Esmeralda", "Escarlata", "Espárrago", "Fucsia", "Fósforo", "Feldgrau", "Frambuesa", "Gris", "Granate", "Glauco", "Gainsboro", "Humo", "Hueso", "Hígado", "Infrarrojo", "Isabelino", "Jade", "Jaspeado", "Kalúa", "Kaki", "Kiwi", "Lavanda", "Lima", "Lila", "Limón", "Ladrillo", "Lino", "Magenta", "Morado", "Marron", "Marfil", "Mostaza", "Malva", "Magnolia", "Miel", "Melón", "Mocasín", "Negro", "Naranja", "Nieve", "Ocre", "Oro", "Oliva", "Púrpura", "Plateado", "Pardo", "Piel", "Perla", "Perú", "Rojo", "Rosado", "Rosa", "Rubio", "Rubí", "Salmón", "Sepia", "Siena", "Sésamo", "Sopa", "Topacio", "Terracota", "Tomate", "Tornasol", "Trigueño", "Turquí", "Turquesa", "Ultravioleta", "Urano", "Uva", "Ultramarino", "Violeta", "Verde", "Vainilla", "Wasabi", "Wisteria", "Xantico", "Xanadu", "Yema", "Yeso", "Yodo", "Zafiro", "Zanahoria", "Zapallo", "Zinc" };
                //List<string> objetos = new List<string> { };
                List<string> lugares = new List<string> { };
                List<string> comidas = new List<string> { "Albóndigas", "Ananá", "Arroz", "Bacalao", "Berenjena", "Bergamota", "Chorizo", "Cerezas", "Coco", "Cerdo", "Dorado", "Donas", "Dulce de leche", "Espárragos", "Empanada", "Estofado", "Flan", "Fresa", "Fresas", "Frutilla", "Frambuesas", "Gelatina", "Guiso", "Gazpacho", "Higo", "Hongos", "Helado", "Ilar", "Indibaba", "Irasagar", "Japuta", "Jamón", "Jibia", "Kiwi", "Ketchup", "Locro", "Limón", "Langosta", "Langostino", "Leche", "Lima", "Macarrones", "Magdalenas", "Manzana", "Maíz", "Nabo", "Nachos", "Naranja", "Ostra", "Orégano", "Omelet", "Paella", "Palometa", "Pan", "Quesadilla", "Queso", "Rabano", "Rabas", "Rana", "Salame", "Salmón", "Salchichón", "Salchicha", "Tarta", "Torta", "Tallarines", "Uva", "Vainilla", "Vinagre" };
                foreach (string str in nombres)
                {
                    clogPal.agregarPalabra(str, str[0], "Nombre");
                }
                foreach (string str in animales)
                {
                    clogPal.agregarPalabra(str, str[0], "Animal");
                }
                foreach (string str in colores)
                {
                    clogPal.agregarPalabra(str, str[0], "Color");
                }
                
                //foreach (string str in objetos)
                //{
                    //clogPal.agregarPalabra(str, str[0], "Objeto");
                //}
                
                foreach (string str in lugares)
                {
                    clogPal.agregarPalabra(str, str[0], "Lugar");
                }
                foreach (string str in comidas)
                {
                    clogPal.agregarPalabra(str, str[0], "Comida");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }
    }
}
