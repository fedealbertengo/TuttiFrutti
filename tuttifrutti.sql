# Host: localhost  (Version 5.7.17-log)
# Date: 2016-12-14 11:40:16
# Generator: MySQL-Front 5.4  (Build 4.57) - http://www.mysqlfront.de/

/*!40101 SET NAMES utf8 */;

#
# Structure for table "banderasjuego"
#

DROP TABLE IF EXISTS `banderasjuego`;
CREATE TABLE `banderasjuego` (
  `IdBandera` int(10) NOT NULL AUTO_INCREMENT,
  `IdJuego` int(10) DEFAULT NULL,
  `NombreUsuario` varchar(255) DEFAULT NULL,
  `Bandera` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`IdBandera`),
  UNIQUE KEY `UniqueKey` (`IdJuego`,`NombreUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

#
# Data for table "banderasjuego"
#

INSERT INTO `banderasjuego` VALUES (1,1,'Pinii','Esperando'),(2,1,'Pini368','Listo');

#
# Structure for table "chat"
#

DROP TABLE IF EXISTS `chat`;
CREATE TABLE `chat` (
  `IdJuego` int(10) NOT NULL,
  `Texto` longtext,
  PRIMARY KEY (`IdJuego`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Data for table "chat"
#

INSERT INTO `chat` VALUES (1,'Pinii:Hola\r\nPinii:Que talco?\r\n');

#
# Structure for table "juego"
#

DROP TABLE IF EXISTS `juego`;
CREATE TABLE `juego` (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(255) DEFAULT NULL,
  `IdPropietario` int(10) DEFAULT NULL,
  `Capacidad` int(10) DEFAULT NULL,
  `Unidos` int(10) DEFAULT NULL,
  `Estado` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

#
# Data for table "juego"
#

INSERT INTO `juego` VALUES (1,'Sala 2',0,4,2,'Jugando'),(2,'Sala 3',0,4,0,'Esperando');

#
# Structure for table "palabras"
#

DROP TABLE IF EXISTS `palabras`;
CREATE TABLE `palabras` (
  `Palabra` varchar(255) NOT NULL,
  `Categoria` varchar(255) NOT NULL,
  `Letra` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`Palabra`,`Categoria`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Data for table "palabras"
#

INSERT INTO `palabras` VALUES ('Aceitunado','Color','A'),('Aguamarina','Color','A'),('Albaricoque','Color','A'),('Albóndigas','Comida','A'),('Alce','Animal','A'),('Alejandro','Nombre','A'),('Alejo','Nombre','A'),('Alfonso','Nombre','A'),('Alfredo','Nombre','A'),('Alicia','Nombre','A'),('Alipio','Nombre','A'),('Almudena','Nombre','A'),('Alvaro','Nombre','A'),('Amadeo','Nombre','A'),('Amaranto','Color','A'),('Amarillo','Color','A'),('Amaro','Nombre','A'),('Amatista','Color','A'),('Ámbar','Color','Á'),('Ambrosio','Nombre','A'),('Amelia o Amalia','Nombre','A'),('Ana','Nombre','A'),('Anaconda','Animal','A'),('Ananá','Comida','A'),('Ananías','Nombre','A'),('Anastasia','Nombre','A'),('Anatolio','Nombre','A'),('Andrés','Nombre','A'),('Ángel','Nombre','Á'),('Añil','Color','A'),('Anselmo','Nombre','A'),('Antero','Nombre','A'),('Antilope','Animal','A'),('Antonio','Nombre','A'),('Aquiles','Nombre','A'),('Araceli','Nombre','A'),('Araña','Animal','A'),('Aránzazu','Nombre','A'),('Arcadio','Nombre','A'),('Aresio','Nombre','A'),('Ariadna','Nombre','A'),('Aristides','Nombre','A'),('Arlequín','Color','A'),('Armiño','Animal','A'),('Arnaldo','Nombre','A'),('Arroz','Comida','A'),('Artemio','Nombre','A'),('Arturo','Nombre','A'),('Atanasio','Nombre','A'),('Augusto','Nombre','A'),('Áurea','Nombre','Á'),('Aurelia','Nombre','A'),('Aureliano','Nombre','A'),('Aurelio','Nombre','A'),('Avellana','Color','A'),('Avestruz','Animal','A'),('Azul','Color','A'),('Azur','Color','A'),('Babuino','Animal','B'),('Bacalao','Comida','B'),('Baldomero','Nombre','B'),('Balduino','Nombre','B'),('Baltasar','Nombre','B'),('Bárbara','Nombre','B'),('Bartolomé','Nombre','B'),('Basileo','Nombre','B'),('Beatriz','Nombre','B'),('Beige','Color','B'),('Belén','Nombre','B'),('Beltrán','Nombre','B'),('Benedicto','Nombre','B'),('Benigno','Nombre','B'),('Benjamín','Nombre','B'),('Berenjena','Comida','B'),('Bergamota','Comida','B'),('Bermellón','Color','B'),('Bernabé','Nombre','B'),('Bernardo','Nombre','B'),('Betamina','Color','B'),('Bisonte','Animal','B'),('BistreIndigo','Color','B'),('Blanca','Nombre','B'),('Blanco','Color','B'),('Blas','Nombre','B'),('Boa','Animal','B'),('Bonifacio','Nombre','B'),('Borgoña','Color','B'),('Borrego','Animal','B'),('Bronceado','Color','B'),('Bruno','Nombre','B'),('Burdeo','Color','B'),('Burro','Animal','B'),('Cabra','Animal','C'),('Cacao','Color','C'),('Cacatúa','Animal','C'),('Café','Color','C'),('Calamar','Animal','C'),('Calixto','Nombre','C'),('Camilo','Nombre','C'),('Canario','Animal','C'),('Cándida','Nombre','C'),('Canela','Color','C'),('Cangrejo','Animal','C'),('Caramelo','Color','C'),('Cardo','Color','C'),('Carina','Nombre','C'),('Carlos','Nombre','C'),('Carmen','Nombre','C'),('Carmesí','Color','C'),('Carmín','Color','C'),('Casiano','Nombre','C'),('Casimiro','Nombre','C'),('Casio','Nombre','C'),('Castaño','Color','C'),('Castor','Animal','C'),('Catalina','Nombre','C'),('Cayetano','Nombre','C'),('Cayo','Nombre','C'),('Cebra','Animal','C'),('Cecilia','Nombre','C'),('Ceferino','Nombre','C'),('Celeste','Color','C'),('Celia','Nombre','C'),('Celso','Nombre','C'),('Cenizo','Color','C'),('Cerdo','Comida','C'),('Cerezas','Comida','C'),('Cerúleo','Color','C'),('Cesáreo','Nombre','C'),('Champagne','Color','C'),('Champán','Color','C'),('Chinchilla','Animal','C'),('Chocolate','Color','C'),('Chorizo','Comida','C'),('Ciano','Color','C'),('Cipriano','Nombre','C'),('Cirilo','Nombre','C'),('Cirino','Nombre','C'),('Ciro','Nombre','C'),('Ciruela','Color','C'),('Claudio','Nombre','C'),('Cleofás','Nombre','C'),('Clotilde','Nombre','C'),('Coco','Comida','C'),('Colombo','Nombre','C'),('Colorado','Color','C'),('Columba','Nombre','C'),('Columbano','Nombre','C'),('Conrado','Nombre','C'),('Constancio','Nombre','C'),('Constantino','Nombre','C'),('Coral','Color','C'),('Cosme','Nombre','C'),('Cotorra','Animal','C'),('Crema','Color','C'),('Cristina','Nombre','C'),('Cristóbal','Nombre','C'),('Daciano','Nombre','D'),('Dacio','Nombre','D'),('Dámaso','Nombre','D'),('Damián','Nombre','D'),('Daniel','Nombre','D'),('Dario','Nombre','D'),('David','Nombre','D'),('Delfin','Animal','D'),('Demócrito','Nombre','D'),('Denim','Color','D'),('Diego','Nombre','D'),('Dimas','Nombre','D'),('Domingo','Nombre','D'),('Donas','Comida','D'),('Donato','Nombre','D'),('Dorado','Color','D'),('Dorado','Comida','D'),('Dorotea','Nombre','D'),('Dragón de komodo','Animal','D'),('Dromedario','Animal','D'),('Dulce de leche','Comida','D'),('Durazno','Color','D'),('Edmundo','Nombre','E'),('Eduardo','Nombre','E'),('Eduvigis','Nombre','E'),('Efrén','Nombre','E'),('Elefante','Animal','E'),('Elena','Nombre','E'),('Elías','Nombre','E'),('Elisa','Nombre','E'),('Eliseo','Nombre','E'),('Emiliano','Nombre','E'),('Emilio','Nombre','E'),('Empanada','Comida','E'),('Enrique','Nombre','E'),('Epifanía','Nombre','E'),('Erico','Nombre','E'),('Erizo','Animal','E'),('Ernesto','Nombre','E'),('Escarabajo','Animal','E'),('Escarlata','Color','E'),('Escorpion','Animal','E'),('Esdras','Nombre','E'),('Esiquio','Nombre','E'),('Esmeralda','Color','E'),('Espárrago','Color','E'),('Espárragos','Comida','E'),('Esponja','Animal','E'),('Esteban','Nombre','E'),('Ester','Nombre','E'),('Estofado','Comida','E'),('Eugenia','Nombre','E'),('Eulalia','Nombre','E'),('Eusebio','Nombre','E'),('Eva','Nombre','E'),('Evaristo','Nombre','E'),('Ezequiel','Nombre','E'),('Fabián','Nombre','F'),('Fabio','Nombre','F'),('Fabiola','Nombre','F'),('Facundo','Nombre','F'),('Faisan','Animal','F'),('Farra','Animal','F'),('Faustino','Nombre','F'),('Fausto','Nombre','F'),('Federico','Nombre','F'),('Feldgrau','Color','F'),('Feliciano','Nombre','F'),('Felipe','Nombre','F'),('Félix','Nombre','F'),('Fermin','Nombre','F'),('Fernando','Nombre','F'),('Fidel','Nombre','F'),('Flamenco','Animal','F'),('Flan','Comida','F'),('Foca','Animal','F'),('Fortunato','Nombre','F'),('Fósforo','Color','F'),('Frambuesa','Color','F'),('Frambuesas','Comida','F'),('Francisco','Nombre','F'),('Fresa','Comida','F'),('Fresas','Comida','F'),('Frutilla','Comida','F'),('Fucsia','Color','F'),('Fulgencio','Nombre','F'),('Gabriel','Nombre','G'),('Gacela','Animal','G'),('Gainsboro','Color','G'),('Garza','Animal','G'),('Gato','Animal','G'),('Gazpacho','Comida','G'),('Gelatina','Comida','G'),('Genoveva','Nombre','G'),('Gerardo','Nombre','G'),('Germán','Nombre','G'),('Gertrudis','Nombre','G'),('Gisela','Nombre','G'),('Glauco','Color','G'),('Godofredo','Nombre','G'),('Golondrina','Animal','G'),('Gonzalo','Nombre','G'),('Gorrion','Animal','G'),('Granate','Color','G'),('Gregorio','Nombre','G'),('Gris','Color','G'),('Guacamayo','Animal','G'),('Guadalupe','Nombre','G'),('Guido','Nombre','G'),('Guillermo','Nombre','G'),('Guiso','Comida','G'),('Guzmán','Nombre','G'),('Halcón','Animal','H'),('Hamster','Animal','H'),('Helado','Comida','H'),('Heliodoro','Nombre','H'),('Heraclio','Nombre','H'),('Heriberto','Nombre','H'),('Hiena','Animal','H'),('Hígado','Color','H'),('Higo','Comida','H'),('Hilarión','Nombre','H'),('Hildegarda','Nombre','H'),('Hipopotamo','Animal','H'),('Homero','Nombre','H'),('Hongos','Comida','H'),('Honorato','Nombre','H'),('Honorio','Nombre','H'),('Hormiga','Animal','H'),('Hueso','Color','H'),('Hugo','Nombre','H'),('Humberto','Nombre','H'),('Humo','Color','H'),('Ibis','Animal','I'),('Ifigenia','Nombre','I'),('Ignacio','Nombre','I'),('Iguana','Animal','I'),('Ilar','Comida','I'),('Ildefonso','Nombre','I'),('Impala','Animal','I'),('Indibaba','Comida','I'),('Inés','Nombre','I'),('Infrarrojo','Color','I'),('Inmaculada','Nombre','I'),('Inocencio','Nombre','I'),('Irasagar','Comida','I'),('Irene','Nombre','I'),('Ireneo','Nombre','I'),('Isaac','Nombre','I'),('Isabel o Elisa','Nombre','I'),('Isabelino','Color','I'),('Isaias','Nombre','I'),('Ismael','Nombre','I'),('Ivon','Nombre','I'),('Jabali','Animal','J'),('Jacinto','Nombre','J'),('Jacob','Nombre','J'),('Jade','Color','J'),('Jaguar','Animal','J'),('Jaime','Nombre','J'),('Jamón','Comida','J'),('Japuta','Comida','J'),('Jaspeado','Color','J'),('Javier','Nombre','J'),('Jeremías','Nombre','J'),('Jerónimo','Nombre','J'),('Jesús','Nombre','J'),('Jibia','Comida','J'),('Jirafa','Animal','J'),('Joaquím','Nombre','J'),('Joel','Nombre','J'),('Jonás','Nombre','J'),('Jorge','Nombre','J'),('Josafat','Nombre','J'),('José','Nombre','J'),('Josué','Nombre','J'),('Juan','Nombre','J'),('Julián','Nombre','J'),('Justino','Nombre','J'),('Juvenal','Nombre','J'),('Kaki','Color','K'),('Kalúa','Color','K'),('Ketchup','Comida','K'),('Kiwi','Animal','K'),('Kiwi','Color','K'),('Kiwi','Comida','K'),('Koala','Animal','K'),('Krill','Animal','K'),('Ladislao','Nombre','L'),('Ladrillo','Color','L'),('Lagartija','Animal','L'),('Lagarto','Animal','L'),('Langosta','Comida','L'),('Langostino','Comida','L'),('Laura','Nombre','L'),('Laureano','Nombre','L'),('Lavanda','Color','L'),('Lázaro','Nombre','L'),('Leandro','Nombre','L'),('Leche','Comida','L'),('Lemur','Animal','L'),('Leocadia','Nombre','L'),('Leon','Animal','L'),('Leonardo','Nombre','L'),('Leoncio','Nombre','L'),('Leonor','Nombre','L'),('Leopoldo','Nombre','L'),('Lidia','Nombre','L'),('Liduvina','Nombre','L'),('Liebre','Animal','L'),('Lila','Color','L'),('Lima','Color','L'),('Lima','Comida','L'),('Limón','Color','L'),('Limón','Comida','L'),('Lince','Animal','L'),('Lino','Color','L'),('Lino','Nombre','L'),('Llama','Animal','L'),('Locro','Comida','L'),('Lorenzo','Nombre','L'),('Lucano','Nombre','L'),('Lucas','Nombre','L'),('Lucía','Nombre','L'),('Luciano','Nombre','L'),('Lucrecia','Nombre','L'),('Luis','Nombre','L'),('Macario','Nombre','M'),('Macarrones','Comida','M'),('Magdalena','Nombre','M'),('Magdalenas','Comida','M'),('Magenta','Color','M'),('Magnolia','Color','M'),('Maíz','Comida','M'),('Malva','Color','M'),('Manatí','Animal','M'),('Mandril','Animal','M'),('Mangosta','Animal','M'),('Manuel','Nombre','M'),('Manzana','Comida','M'),('Marcelino','Nombre','M'),('Marcelo','Nombre','M'),('Marcial','Nombre','M'),('Marciano','Nombre','M'),('Marcos','Nombre','M'),('Marfil','Color','M'),('Margarita','Nombre','M'),('María','Nombre','M'),('Mariano','Nombre','M'),('Marina','Nombre','M'),('Mario','Nombre','M'),('Marmota','Animal','M'),('Marron','Color','M'),('Marta','Nombre','M'),('Martín','Nombre','M'),('Mateo','Nombre','M'),('Matías','Nombre','M'),('Matilde','Nombre','M'),('Mauricio','Nombre','M'),('Maximiliano','Nombre','M'),('Melchor','Nombre','M'),('Melón','Color','M'),('Mercedes','Nombre','M'),('Miel','Color','M'),('Miguel','Nombre','M'),('Miqueas','Nombre','M'),('Mocasín','Color','M'),('Moisés','Nombre','M'),('Mónica','Nombre','M'),('Mono','Animal','M'),('Montserrat','Nombre','M'),('Morado','Color','M'),('Morsa','Animal','M'),('Mosca','Animal','M'),('Mostaza','Color','M'),('Nabo','Comida','N'),('Nachos','Comida','N'),('Ñandu','Animal','Ñ'),('Naranja','Color','N'),('Naranja','Comida','N'),('Narciso','Nombre','N'),('Natalia','Nombre','N'),('Nauyaca(serpiente)','Animal','N'),('Nazario','Nombre','N'),('Negro','Color','N'),('Nemesio','Nombre','N'),('Nicanor','Nombre','N'),('Nicodemo','Nombre','N'),('Nicolás','Nombre','N'),('Nicomedes','Nombre','N'),('Nieve','Color','N'),('Nieves','Nombre','N'),('Noé','Nombre','N'),('Norberto','Nombre','N'),('Ñu','Animal','Ñ'),('Nutria','Animal','N'),('Ocelote','Animal','O'),('Ocre','Color','O'),('Octavio','Nombre','O'),('Odón','Nombre','O'),('Oliva','Color','O'),('Omelet','Comida','O'),('Onésimo','Nombre','O'),('Orca','Animal','O'),('Orégano','Comida','O'),('Orestes','Nombre','O'),('Oriol','Nombre','O'),('Ornitorrinco','Animal','O'),('Oro','Color','O'),('Óscar','Nombre','Ó'),('Oseas','Nombre','O'),('Oso','Animal','O'),('Ostra','Comida','O'),('Oswaldo','Nombre','O'),('Otilia','Nombre','O'),('Oto','Nombre','O'),('Oveja','Animal','O'),('Pablo','Nombre','P'),('Paella','Comida','P'),('Paloma','Animal','P'),('Palometa','Comida','P'),('Pan','Comida','P'),('Pancracio','Nombre','P'),('Pardo','Color','P'),('Pato','Animal','P'),('Patricio','Nombre','P'),('Paula','Nombre','P'),('Pedro','Nombre','P'),('Pelícano','Animal','P'),('Perla','Color','P'),('Perro','Animal','P'),('Perú','Color','P'),('Petronila','Nombre','P'),('Pez','Animal','P'),('Piel','Color','P'),('Pingüino','Animal','P'),('Pío','Nombre','P'),('Plateado','Color','P'),('Porfirio','Nombre','P'),('Púrpura','Color','P'),('Quesadilla','Comida','Q'),('Queso','Comida','Q'),('Quetzal','Animal','Q'),('Quirquincho','Animal','Q'),('Quitón','Animal','Q'),('Rabano','Comida','R'),('Rabas','Comida','R'),('Ramón','Nombre','R'),('Rana','Animal','R'),('Rana','Comida','R'),('Raton','Animal','R'),('Raya','Animal','R'),('Rebeca','Nombre','R'),('Reno','Animal','R'),('Rinoceronte','Animal','R'),('Rogelio','Nombre','R'),('Rojo','Color','R'),('Roque','Nombre','R'),('Rosa','Color','R'),('Rosado','Color','R'),('Rosalia','Nombre','R'),('Rosario','Nombre','R'),('Rosendo','Nombre','R'),('Rubí','Color','R'),('Rubio','Color','R'),('Rufo','Nombre','R'),('Ruperto','Nombre','R'),('Salamandra','Animal','S'),('Salame','Comida','S'),('Salchicha','Comida','S'),('Salchichón','Comida','S'),('Salmon','Animal','S'),('Salmón','Color','S'),('Salmón','Comida','S'),('Salomé','Nombre','S'),('Salomón','Nombre','S'),('Saltamontes','Animal','S'),('Salvador','Nombre','S'),('Salvio','Nombre','S'),('Samuel','Nombre','S'),('Sansón','Nombre','S'),('Santiago','Nombre','S'),('Sapo','Animal','S'),('Sara','Nombre','S'),('Sardina','Animal','S'),('Sebastián','Nombre','S'),('Segismundo','Nombre','S'),('Sepia','Color','S'),('Sergio','Nombre','S'),('Serpiente','Animal','S'),('Sésamo','Color','S'),('Severino','Nombre','S'),('Siena','Color','S'),('Simeón','Nombre','S'),('Simón','Nombre','S'),('Siro','Nombre','S'),('Sixto','Nombre','S'),('Sofía','Nombre','S'),('Sopa','Color','S'),('Suricata','Animal','S'),('Susana','Nombre','S'),('Tadeo','Nombre','T'),('Tallarines','Comida','T'),('Tarsicio','Nombre','T'),('Tarta','Comida','T'),('Tejón','Animal','T'),('Teodora','Nombre','T'),('Teodosia','Nombre','T'),('Teófanes','Nombre','T'),('Teófila','Nombre','T'),('Teresa','Nombre','T'),('Terracota','Color','T'),('Tiburon','Animal','T'),('Tigre','Animal','T'),('Timoteo','Nombre','T'),('Tito','Nombre','T'),('Tobías','Nombre','T'),('Tomás','Nombre','T'),('Tomate','Color','T'),('Topacio','Color','T'),('Topo','Animal','T'),('Toribio','Nombre','T'),('Tornasol','Color','T'),('Toro','Animal','T'),('Torta','Comida','T'),('Tortuga','Animal','T'),('Trigueño','Color','T'),('Tucán','Animal','T'),('Turquesa','Color','T'),('Turquí','Color','T'),('Uapití','Animal','U'),('Ubaldo','Nombre','U'),('Ultramarino','Color','U'),('Ultravioleta','Color','U'),('Urano','Color','U'),('Urbano','Nombre','U'),('Uro','Animal','U'),('Urogallo','Animal','U'),('Urraca','Animal','U'),('Ursula','Nombre','U'),('Uva','Color','U'),('Uva','Comida','U'),('Vaca','Animal','V'),('Vainilla','Color','V'),('Vainilla','Comida','V'),('Valentín','Nombre','V'),('Valeriano','Nombre','V'),('Velerio','Nombre','V'),('Venado','Animal','V'),('Venancio','Nombre','V'),('Verde','Color','V'),('Verónica','Nombre','V'),('Vicente','Nombre','V'),('Víctor','Nombre','V'),('Victorino','Nombre','V'),('Victorio','Nombre','V'),('Vicuña','Animal','V'),('Vidal','Nombre','V'),('Vinagre','Comida','V'),('Violeta','Color','V'),('Virgilio','Nombre','V'),('Vizcacha','Animal','V'),('Vladimiro','Nombre','V'),('Walabi','Animal','W'),('Wasabi','Color','W'),('Wilfredo','Nombre','W'),('Wisteria','Color','W'),('Wombat','Animal','W'),('Xanadu','Color','X'),('Xantico','Color','X'),('Xantus','Animal','X'),('Xoloizcuintle(es un perro mexicano)','Animal','X'),('Yaguarete','Animal','Y'),('Yak','Animal','Y'),('Yegua','Animal','Y'),('Yema','Color','Y'),('Yeso','Color','Y'),('Yodo','Color','Y'),('Zacarías','Nombre','Z'),('Zafiro','Color','Z'),('Zanahoria','Color','Z'),('Zapallo','Color','Z'),('Zaqueo','Nombre','Z'),('Zarigüeya','Animal','Z'),('Zinc','Color','Z'),('Zorro','Animal','Z');

#
# Structure for table "ronda"
#

DROP TABLE IF EXISTS `ronda`;
CREATE TABLE `ronda` (
  `IdRespuesta` int(10) NOT NULL AUTO_INCREMENT,
  `Jugador` varchar(255) DEFAULT NULL,
  `IdJuego` int(10) DEFAULT NULL,
  `NroRonda` int(10) DEFAULT NULL,
  `Letra` varchar(1) DEFAULT NULL,
  `Nombre` varchar(255) DEFAULT NULL,
  `Animal` varchar(255) DEFAULT NULL,
  `Color` varchar(255) DEFAULT NULL,
  `Objeto` varchar(255) DEFAULT NULL,
  `Lugar` varchar(255) DEFAULT NULL,
  `Comida` varchar(255) DEFAULT NULL,
  `Puntos` int(10) DEFAULT NULL,
  `TuttiFrutti` int(10) DEFAULT NULL,
  PRIMARY KEY (`IdRespuesta`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

#
# Data for table "ronda"
#

INSERT INTO `ronda` VALUES (1,'Pinii',1,0,'T','TOMÁS','TIGRE','TORNAZOLADO','TRENZA','TANZANIA','TOMATE',20,1);

#
# Structure for table "usuario"
#

DROP TABLE IF EXISTS `usuario`;
CREATE TABLE `usuario` (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `NombreUsuario` varchar(255) DEFAULT NULL,
  `Contraseña` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NombreUsuario` (`NombreUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

#
# Data for table "usuario"
#

INSERT INTO `usuario` VALUES (1,'Pinii','hola12'),(2,'Pini368','hola12');
