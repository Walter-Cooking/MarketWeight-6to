Use 5to_MarketWeight

ALTER DATABASE 5to_MarketWeight CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
CALL AltaCriptoMoneda(100.50, 100, 'Bitcoin');
CALL AltaCriptoMoneda(50.25, 100, 'Ethereum');
CALL AltaCriptoMoneda(75.00, 100, 'Ripple');
CALL AltaCriptoMoneda(20.75, 100, 'Litecoin');
CALL AltaCriptoMoneda(30.10, 100, 'Cardano');
CALL AltaCriptoMoneda(60.80, 100, 'Polkadot');
CALL AltaCriptoMoneda(90.00, 100, 'Chainlink');
CALL AltaCriptoMoneda(110.15, 100, 'Stellar');
CALL AltaCriptoMoneda(40.60, 100, 'Dogecoin');
CALL AltaCriptoMoneda(70.85, 100, 'Tron');
CALL AltaUsuario('Ana', 'García', 'ana.garcia@example.com', 'pass1234',0.0);
CALL AltaUsuario('Luis', 'Martínez', 'luis.martinez@example.com', '1234abcd',0.0);
CALL AltaUsuario('Marta', 'Fernández', 'marta.fernandez@example.com', 'abcd1234',0.0);
CALL AltaUsuario('Carlos', 'Gómez', 'carlos.gomez@example.com', 'qwerty12',0.0);
CALL AltaUsuario('Laura', 'Rodríguez', 'laura.rodriguez@example.com', 'password',0.0);
CALL AltaUsuario('Pedro', 'López', 'pedro.lopez@example.com', 'abcd1234',0.0);
CALL AltaUsuario('Sofía', 'Hernández', 'sofia.hernandez@example.com', '12345678',0.0);
CALL AltaUsuario('Daniel', 'Pérez', 'daniel.perez@example.com', '1q2w3e4r',0.0);
CALL AltaUsuario('María', 'Torres', 'maria.torres@example.com', 'letmein1',0.0);
CALL AltaUsuario('Javier', 'Ramírez', 'javier.ramirez@example.com', 'welcome1',0.0);
CALL IngresarDinero(2, 0);
CALL IngresarDinero(3, 10000);
CALL IngresarDinero(2, 10000);

CALL ComprarMoneda (2, 3, 2);
CALL Transferencia (2, 0.5, 2, 3);

SET SQL_SAFE_UPDATES = 0;

UPDATE usuario SET apellido = "Garcia" WHERE email = 'ana.garcia@example.com';

UPDATE usuario SET apellido = 'Martínez' WHERE email = 'luis.martinez@example.com';
UPDATE usuario SET apellido = 'Fernández' WHERE email = 'marta.fernandez@example.com';
UPDATE usuario SET apellido = 'Gómez' WHERE email = 'carlos.gomez@example.com';
UPDATE usuario SET apellido = 'Rodríguez' WHERE email = 'laura.rodriguez@example.com';
UPDATE usuario SET apellido = 'López' WHERE email = 'pedro.lopez@example.com';
UPDATE usuario SET apellido = 'Hernández' WHERE email = 'sofia.hernandez@example.com';
UPDATE usuario SET apellido = 'Pérez' WHERE email = 'daniel.perez@example.com';
UPDATE usuario SET apellido = 'Ramírez' WHERE email = 'javier.ramirez@example.com';
UPDATE usuario SET nombre = 'Sofía' WHERE email = 'sofia.hernandez@example.com';
UPDATE usuario SET nombre = 'María' WHERE email = 'maria.torres@example.com';
SET SQL_SAFE_UPDATES = 1;