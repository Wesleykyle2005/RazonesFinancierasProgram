-- Crear la base de datos
CREATE DATABASE FinanzasDB;
USE FinanzasDB;

-- Crear tabla Empresa
CREATE TABLE Empresa (
    IdEmpresa INT IDENTITY(1,1) PRIMARY KEY,
    NombreEmpresa VARCHAR(255) NOT NULL,
    RUC VARCHAR(20), -- Registro Único del Contribuyente
    Direccion VARCHAR(255),
    Telefono VARCHAR(20)
);

-- Crear tablas de cuentas
CREATE TABLE Activos (
    IdActivo INT IDENTITY(1,1) PRIMARY KEY,
    NombreCuenta VARCHAR(100) NOT NULL,
    Clasificacion VARCHAR(50) NOT NULL,
    Valor DECIMAL(15, 2) NOT NULL
);

CREATE TABLE Pasivos (
    IdPasivo INT IDENTITY(1,1) PRIMARY KEY,
    NombreCuenta VARCHAR(100) NOT NULL,
    Clasificacion VARCHAR(50) NOT NULL,
    Valor DECIMAL(15, 2) NOT NULL
);

CREATE TABLE Capital (
    IdCapital INT IDENTITY(1,1) PRIMARY KEY,
    NombreCuenta VARCHAR(100) NOT NULL,
    Clasificacion VARCHAR(50) NOT NULL,
    Valor DECIMAL(15, 2) NOT NULL
);

CREATE TABLE Costos (
    IdCosto INT IDENTITY(1,1) PRIMARY KEY,
    NombreCuenta VARCHAR(100) NOT NULL,
    Clasificacion VARCHAR(50) NOT NULL,
    Valor DECIMAL(15, 2) NOT NULL
);

CREATE TABLE Ventas (
    IdVenta INT IDENTITY(1,1) PRIMARY KEY,
    NombreCuenta VARCHAR(100) NOT NULL,
    Clasificacion VARCHAR(50) NOT NULL,
    Valor DECIMAL(15, 2) NOT NULL
);

CREATE TABLE Gastos (
    IdGasto INT IDENTITY(1,1) PRIMARY KEY,
    NombreCuenta VARCHAR(100) NOT NULL,
    Clasificacion VARCHAR(50) NOT NULL,
    Valor DECIMAL(15, 2) NOT NULL
);

CREATE TABLE OtrosIngresos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreCuenta VARCHAR(255),
    Clasificacion VARCHAR(255),
    Valor DECIMAL(10, 2)
);

-- Crear tabla intermedia CuentaEmpresa
CREATE TABLE CuentaEmpresa (
    IdCuentaEmpresa INT IDENTITY(1,1) PRIMARY KEY,
    IdEmpresa INT NOT NULL,
    IdCuenta INT NOT NULL,
    TipoCuenta VARCHAR(50) NOT NULL,
    FOREIGN KEY (IdEmpresa) REFERENCES Empresa(IdEmpresa)
);

-- Insertar datos en la tabla Empresa
INSERT INTO Empresa (NombreEmpresa, RUC, Direccion, Telefono)
VALUES
('Empresa ABC', '001-123456789-0', 'Av. Principal 123, Ciudad', '555-1234');

-- Insertar datos en las tablas de cuentas
-- Ventas
INSERT INTO Ventas (NombreCuenta, Clasificacion, Valor)
VALUES
('Ventas', 'Ingresos', 500000.00),
('Descuentos sobre ventas', 'Devoluciones', -44500.00),
('Devoluciones sobre ventas', 'Devoluciones', -35000.00);

-- Costos
INSERT INTO Costos (NombreCuenta, Clasificacion, Valor)
VALUES
('Inventario Inicial', 'Compras', 100000.00),
('Compras', 'Compras', 90000.00),
('Gastos de compras', 'Compras', 10000.00),
('Descuentos sobre Compra', 'Descuentos', -10000.00),
('Inventario Final', 'Compras', -20000.00);

-- Gastos
INSERT INTO Gastos (NombreCuenta, Clasificacion, Valor)
VALUES
('Sueldos y comisiones a vendedores', 'Gastos de Venta', 67600.00),
('Sueldos de la oficina de ventas', 'Gastos de Venta', 40000.00),
('Viáticos', 'Gastos de Venta', 25000.00),
('Fletes de mercancía remitidas', 'Gastos de Venta', 40000.00),
('Depreciación del equipo de transporte', 'Gastos de Venta', 8500.00),
('Teléfono', 'Gastos de Venta', 9000.00),
('Sueldos de oficina', 'Gastos Administrativos', 39999.00),
('Servicios públicos', 'Gastos Administrativos', 12129.00),
('Depreciación del edificio', 'Gastos Administrativos', 4000.00),
('Depreciación del equipo de oficina', 'Gastos Administrativos', 3000.00);

-- Activos
INSERT INTO Activos (NombreCuenta, Clasificacion, Valor)
VALUES
('Efectivo y Valores realizables', 'Activo Circulante', 20000.00),
('Cuentas por Cobrar', 'Activo Circulante', 26000.00),
('Anticipo a Proveedores', 'Activo Circulante', 8600.00),
('Provisión cuentas incobrables', 'Activo Circulante', -1200.00),
('Inventarios', 'Activo Circulante', 25400.00),
('Inmuebles Maquinaria y Equipo', 'Activo No Circulante', 154000.00),
('Depreciación Acumulada', 'Activo No Circulante', -10400.00);

-- Pasivos
INSERT INTO Pasivos (NombreCuenta, Clasificacion, Valor)
VALUES
('Proveedores', 'Pasivo Corto Plazo', 5650.00),
('Acreedores Bancarios corto plazo', 'Pasivo Corto Plazo', 28200.00),
('Impuestos por pagar', 'Pasivo Corto Plazo', 1450.00),
('Documentos por pagar LP', 'Pasivo Largo Plazo', 32000.00),
('Acreedores Hipotecarios', 'Pasivo Largo Plazo', 6800.00),
('Obligaciones', 'Pasivo Largo Plazo', 31600.00);

-- Capital
INSERT INTO Capital (NombreCuenta, Clasificacion, Valor)
VALUES
('Capital Social', 'Capital Contribuido', 57600.00),
('Reserva Legal', 'Capital Ganado', 31400.00),
('Reserva de Reinversión', 'Capital Ganado', 19150.00),
('Utilidad de Ejercicios Anteriores', 'Capital Ganado', 6000.00),
('Utilidad del Ejercicio', 'Capital Ganado', 2550.00);

-- OtrosIngresos
INSERT INTO OtrosIngresos (NombreCuenta, Clasificacion, Valor)
VALUES
('Dividendos cobrados', 'Ingresos Financieros', 2728.00);






-- Relacionar todas las cuentas con Empresa ABC (IdEmpresa = 1)
-- Activos
INSERT INTO CuentaEmpresa (IdEmpresa, IdCuenta, TipoCuenta)
SELECT 1, IdActivo, 'Activos'
FROM Activos;

-- Pasivos
INSERT INTO CuentaEmpresa (IdEmpresa, IdCuenta, TipoCuenta)
SELECT 1, IdPasivo, 'Pasivos'
FROM Pasivos;

-- Capital
INSERT INTO CuentaEmpresa (IdEmpresa, IdCuenta, TipoCuenta)
SELECT 1, IdCapital, 'Capital'
FROM Capital;

-- Costos
INSERT INTO CuentaEmpresa (IdEmpresa, IdCuenta, TipoCuenta)
SELECT 1, IdCosto, 'Costos'
FROM Costos;

-- Ventas
INSERT INTO CuentaEmpresa (IdEmpresa, IdCuenta, TipoCuenta)
SELECT 1, IdVenta, 'Ventas'
FROM Ventas;

-- Gastos
INSERT INTO CuentaEmpresa (IdEmpresa, IdCuenta, TipoCuenta)
SELECT 1, IdGasto, 'Gastos'
FROM Gastos;

-- OtrosIngresos
INSERT INTO CuentaEmpresa (IdEmpresa, IdCuenta, TipoCuenta)
SELECT 1, Id, 'OtrosIngresos'
FROM OtrosIngresos;


SELECT * FROM CuentaEmpresa;

SELECT * FROM fnCuentasPorEmpresa(1);




CREATE FUNCTION fnCuentasPorEmpresa (@IdEmpresa INT)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        E.NombreEmpresa,
        CE.TipoCuenta,
        CASE 
            WHEN CE.TipoCuenta = 'Activos' THEN A.NombreCuenta
            WHEN CE.TipoCuenta = 'Pasivos' THEN P.NombreCuenta
            WHEN CE.TipoCuenta = 'Capital' THEN C.NombreCuenta
            WHEN CE.TipoCuenta = 'Costos' THEN CO.NombreCuenta
            WHEN CE.TipoCuenta = 'Ventas' THEN V.NombreCuenta
            WHEN CE.TipoCuenta = 'Gastos' THEN G.NombreCuenta
            WHEN CE.TipoCuenta = 'OtrosIngresos' THEN OI.NombreCuenta
        END AS NombreCuenta,
        CASE 
            WHEN CE.TipoCuenta = 'Activos' THEN A.Clasificacion
            WHEN CE.TipoCuenta = 'Pasivos' THEN P.Clasificacion
            WHEN CE.TipoCuenta = 'Capital' THEN C.Clasificacion
            WHEN CE.TipoCuenta = 'Costos' THEN CO.Clasificacion
            WHEN CE.TipoCuenta = 'Ventas' THEN V.Clasificacion
            WHEN CE.TipoCuenta = 'Gastos' THEN G.Clasificacion
            WHEN CE.TipoCuenta = 'OtrosIngresos' THEN OI.Clasificacion
        END AS Clasificacion,
        CASE 
            WHEN CE.TipoCuenta = 'Activos' THEN A.Valor
            WHEN CE.TipoCuenta = 'Pasivos' THEN P.Valor
            WHEN CE.TipoCuenta = 'Capital' THEN C.Valor
            WHEN CE.TipoCuenta = 'Costos' THEN CO.Valor
            WHEN CE.TipoCuenta = 'Ventas' THEN V.Valor
            WHEN CE.TipoCuenta = 'Gastos' THEN G.Valor
            WHEN CE.TipoCuenta = 'OtrosIngresos' THEN OI.Valor
        END AS Valor
    FROM 
        CuentaEmpresa CE
    JOIN Empresa E ON CE.IdEmpresa = E.IdEmpresa
    LEFT JOIN Activos A ON CE.TipoCuenta = 'Activos' AND CE.IdCuenta = A.IdActivo
    LEFT JOIN Pasivos P ON CE.TipoCuenta = 'Pasivos' AND CE.IdCuenta = P.IdPasivo
    LEFT JOIN Capital C ON CE.TipoCuenta = 'Capital' AND CE.IdCuenta = C.IdCapital
    LEFT JOIN Costos CO ON CE.TipoCuenta = 'Costos' AND CE.IdCuenta = CO.IdCosto
    LEFT JOIN Ventas V ON CE.TipoCuenta = 'Ventas' AND CE.IdCuenta = V.IdVenta
    LEFT JOIN Gastos G ON CE.TipoCuenta = 'Gastos' AND CE.IdCuenta = G.IdGasto
    LEFT JOIN OtrosIngresos OI ON CE.TipoCuenta = 'OtrosIngresos' AND CE.IdCuenta = OI.Id
    WHERE E.IdEmpresa = @IdEmpresa
);


---string query = "SELECT * FROM fnCuentasPorEmpresa(@IdEmpresa)";
---SqlCommand cmd = new SqlCommand(query, connection);
---cmd.Parameters.AddWithValue("@IdEmpresa", 1);

---


CREATE PROCEDURE spActualizarCuenta
    @TipoCuenta NVARCHAR(50),
    @NombreCuenta NVARCHAR(100),
    @Clasificacion NVARCHAR(50),
    @Valor DECIMAL(15, 2)
AS
BEGIN
    SET NOCOUNT ON;

    IF @TipoCuenta = 'Activos'
    BEGIN
        UPDATE Activos
        SET NombreCuenta = @NombreCuenta, Clasificacion = @Clasificacion, Valor = @Valor
        WHERE NombreCuenta = @NombreCuenta;
    END
    ELSE IF @TipoCuenta = 'Pasivos'
    BEGIN
        UPDATE Pasivos
        SET NombreCuenta = @NombreCuenta, Clasificacion = @Clasificacion, Valor = @Valor
        WHERE NombreCuenta = @NombreCuenta;
    END
    ELSE IF @TipoCuenta = 'Capital'
    BEGIN
        UPDATE Capital
        SET NombreCuenta = @NombreCuenta, Clasificacion = @Clasificacion, Valor = @Valor
        WHERE NombreCuenta = @NombreCuenta;
    END
	ELSE IF @TipoCuenta = 'Ventas'
    BEGIN
        UPDATE Pasivos
        SET NombreCuenta = @NombreCuenta, Clasificacion = @Clasificacion, Valor = @Valor
        WHERE NombreCuenta = @NombreCuenta;
    END
    ELSE IF @TipoCuenta = 'Gastos'
    BEGIN
        UPDATE Capital
        SET NombreCuenta = @NombreCuenta, Clasificacion = @Clasificacion, Valor = @Valor
        WHERE NombreCuenta = @NombreCuenta;
    END
	ELSE IF @TipoCuenta = 'OtrosIngresos'
    BEGIN
        UPDATE Capital
        SET NombreCuenta = @NombreCuenta, Clasificacion = @Clasificacion, Valor = @Valor
        WHERE NombreCuenta = @NombreCuenta;
    END
    
END




CREATE PROCEDURE spAgregarCuenta
    @IdEmpresa INT, @TipoCuenta NVARCHAR(50), @NombreCuenta NVARCHAR(100), @Clasificacion NVARCHAR(50), @Valor DECIMAL(15, 2)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @IdCuenta INT;
    -- Inserta en la tabla correspondiente según el tipo de cuenta
    IF @TipoCuenta = 'Activos'
    BEGIN
        INSERT INTO Activos (NombreCuenta, Clasificacion, Valor) VALUES (@NombreCuenta, @Clasificacion, @Valor);
        SET @IdCuenta = SCOPE_IDENTITY();
    END
    ELSE IF @TipoCuenta = 'Pasivos'
    BEGIN
        INSERT INTO Pasivos (NombreCuenta, Clasificacion, Valor) VALUES (@NombreCuenta, @Clasificacion, @Valor);
        SET @IdCuenta = SCOPE_IDENTITY();
    END
    ELSE IF @TipoCuenta = 'Capital'
    BEGIN
        INSERT INTO Capital (NombreCuenta, Clasificacion, Valor) VALUES (@NombreCuenta, @Clasificacion, @Valor);
        SET @IdCuenta = SCOPE_IDENTITY();
    END
    ELSE IF @TipoCuenta = 'Costos'
    BEGIN
        INSERT INTO Costos (NombreCuenta, Clasificacion, Valor) VALUES (@NombreCuenta, @Clasificacion, @Valor);
        SET @IdCuenta = SCOPE_IDENTITY();
    END
    ELSE IF @TipoCuenta = 'Ventas'
    BEGIN
        INSERT INTO Ventas (NombreCuenta, Clasificacion, Valor)  VALUES (@NombreCuenta, @Clasificacion, @Valor);
        SET @IdCuenta = SCOPE_IDENTITY();
    END
    ELSE IF @TipoCuenta = 'Gastos'
    BEGIN
        INSERT INTO Gastos (NombreCuenta, Clasificacion, Valor) VALUES (@NombreCuenta, @Clasificacion, @Valor);
        SET @IdCuenta = SCOPE_IDENTITY();
    END
    ELSE IF @TipoCuenta = 'OtrosIngresos'
    BEGIN
        INSERT INTO OtrosIngresos (NombreCuenta, Clasificacion, Valor) VALUES (@NombreCuenta, @Clasificacion, @Valor);
        SET @IdCuenta = SCOPE_IDENTITY();
    END
    -- Relacionar la cuenta con la empresa en CuentaEmpresa
    INSERT INTO CuentaEmpresa (IdEmpresa, TipoCuenta, IdCuenta) VALUES (@IdEmpresa, @TipoCuenta, @IdCuenta);
END




SELECT 
                    SUM(CASE WHEN CE.TipoCuenta = 'Ventas' THEN V.Valor ELSE 0 END) AS TotalVentas,
                    SUM(CASE 
                        WHEN CE.TipoCuenta = 'Activos' AND A.Clasificacion = 'Activo No Circulante' AND A.NombreCuenta = 'Inmuebles Maquinaria y Equipo' 
                        THEN A.Valor 
                        ELSE 0 
                    END) AS TotalActivosFijos
                FROM CuentaEmpresa CE
                JOIN Empresa E ON CE.IdEmpresa = E.IdEmpresa
                LEFT JOIN Ventas V ON CE.TipoCuenta = 'Ventas' AND CE.IdCuenta = V.IdVenta
                LEFT JOIN Activos A ON CE.TipoCuenta = 'Activos' AND CE.IdCuenta = A.IdActivo
                WHERE E.IdEmpresa = 1
                GROUP BY E.IdEmpresa;
