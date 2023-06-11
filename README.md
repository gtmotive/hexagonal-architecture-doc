# Lenguaje Ubicuo

## Dominio

GT Motive gestiona una flota de vehículos disponibles para alquiler. Los clientes pueden reservar vehículos, y la empresa se encarga de gestionar los alquileres y las devoluciones. 

## Entidades 

### Vehículo

Un `Vehículo` es una parte fundamental de la flota de la empresa. Cada vehículo tiene las siguientes propiedades:

- `Id` (Guid): Es un identificador único para cada vehículo.
- `Model` (Model): El modelo del vehículo, que incluye la marca y el nombre.
- `ManufacturingDate` (DateOnly): La fecha de fabricación del vehículo.
- `IsAvailable` (bool): Un indicador de si el vehículo está disponible para alquilar.

### Cliente

Un `Cliente` es una persona que alquila vehículos mediante una reserva. Cada cliente tiene las siguientes propiedades:

- `Id` (Guid): Es un identificador único para cada cliente.
- `Name` (string): El nombre completo del cliente.
- `Bookings` (IReadOnlyList<VehicleBooking>): La lista de las reservas hechas por el cliente.

Los clientes pueden reservar vehículos siempre que no tengan ninguna reserva activa.

### Reserva de Vehículo (VehicleBooking)

Una `Reserva de Vehículo` es una reserva hecha por un cliente. Cada reserva tiene las siguientes propiedades:

- `Id` (Guid): Es un identificador único para cada reserva.
- `BookingDate` (DateOnly): La fecha en que se hizo la reserva.
- `ReturnDate` (DateOnly): La fecha en que se debe devolver el vehículo.
- `VehicleId` (Guid): El identificador del vehículo reservado.
- `IsActive` (bool): Un indicador de si la reserva está activa.

Las reservas pueden ser desactivadas, lo que sucede cuando el vehículo es devuelto.

## Comportamientos

El sistema debe permitir las siguientes acciones a través de llamadas REST:

- **Gestionar la creación de nuevos vehículos**: Esto implica agregar nuevos vehículos a la flota.
- **Listar los vehículos disponibles**: Esto implica proporcionar una lista de todos los vehículos disponibles para alquilar.
- **Alquilar un vehículo**: Esto implica que un cliente reserve un vehículo disponible.
- **Devolución del vehículo**: Esto implica que un cliente devuelva un vehículo que ha alquilado.