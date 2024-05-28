CREATE OR REPLACE TABLE Persona (
    Dni VARCHAR(9) PRIMARY KEY,
    nom VARCHAR(100),
    cognom VARCHAR(100),
    password VARCHAR(100),
    esAdmin VARCHAR (2)
);
CREATE OR REPLACE TABLE Restaurant (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(100),
    direccio VARCHAR(200),
    tipusCuina VARCHAR(100),
    capacitat INT,
    Dni VARCHAR(9),
    FOREIGN KEY (Dni) REFERENCES Persona(Dni) 
);
CREATE OR REPLACE TABLE Valoracio (
    id INT AUTO_INCREMENT PRIMARY KEY,
    comentari VARCHAR(500),
    puntuacio INT,
    Dni VARCHAR(9),
    idRestaurant INT,
    FOREIGN KEY (Dni) REFERENCES Persona(Dni),
    FOREIGN KEY (idRestaurant) REFERENCES Restaurant(id)
);

CREATE OR REPLACE TABLE Reserva (
    idReserva INT AUTO_INCREMENT PRIMARY KEY,
    data DATE,
    hora TIME,
    numComensales INT,
    preferencies VARCHAR(200),
    Dni VARCHAR(9),
    idRestaurant INT,
    nomTaula VARCHAR(100),
    FOREIGN KEY (Dni) REFERENCES Persona(Dni),
    FOREIGN KEY (idRestaurant) REFERENCES Restaurant(id)
);
CREATE OR REPLACE TABLE Fotos (
    idFoto INT AUTO_INCREMENT PRIMARY KEY,
    url VARCHAR(500),
    idRestaurant INT,
    FOREIGN KEY (idRestaurant) REFERENCES Restaurant(id)
);

INSERT INTO Persona (Dni, nom, cognom,password,esAdmin)
VALUES ('12345678B', 'Marc', 'Pérez', '12345', 'si');

SELECT * FROM persona WHERE dni = '12345678A' AND password = '12345';
SELECT * FROM persona;

INSERT INTO restaurant (nom,direccio,tipusCuina,capacitat,Dni)
VALUES ('HOLA','Joan 1','Grill',100,'12345678A');

SELECT * FROM restaurant; 

INSERT INTO valoracio (comentari,puntuacio,dni,idRestaurant)
VALUES ('Bueno',7,'77924452S',1);

INSERT INTO fotos (url,idRestaurant)
VALUES ('b',1);

INSERT INTO fotos (url, idRestaurant)
SELECT 'c', id
FROM restaurant 
WHERE nom = 'HOLA';

INSERT INTO reserva (`data`,hora,numComensales,preferencies,Dni,idRestaurant,nomTaula)
VALUES ('2024-05-20', '19:00:00', 3, 'Ninguna', '12345678A', 1, 'Taula 1')


SELECT * FROM restaurant ;
SELECT * FROM fotos f ;
SELECT * FROM reserva r ;

SELECT f.url 
FROM fotos f 
JOIN restaurant r ON f.idRestaurant = r.id
WHERE r.nom = 'HOLA';

SELECT id, r.`data` ,r.hora ,r.numComensales ,r.preferencies ,r.Dni 
FROM reserva r 
JOIN restaurant r2 ON r.idRestaurant = r2.id
WHERE r2.nom = 'HOLA2';

SELECT * FROM reserva WHERE dni = '77924452S';

SELECT v.comentari, v.puntuacio, v.Dni
FROM valoracio v 
JOIN restaurant r ON v.idRestaurant = r.id
WHERE r.nom = 'HOLA2';

SELECT * FROM valoracio WHERE Dni = '77924452S';



DELETE FROM fotos WHERE idRestaurant = (SELECT id FROM restaurant WHERE nom = 'HOLA');
DELETE FROM reserva WHERE idRestaurant = (SELECT id FROM restaurant WHERE nom = 'HOLA2');
DELETE FROM reserva WHERE idReserva = 7;
DELETE FROM valoracio WHERE idRestaurant IN (SELECT id FROM restaurant WHERE nom = 'HOLA2')


INSERT INTO Reserva (data, hora, numComensales, preferencies, Dni, idRestaurant,nomTaula)
VALUES('2024-05-20','19:00:00',4,'','77924452S',(SELECT id FROM Restaurant WHERE nom = 'HOLA2'),'taula 1');



