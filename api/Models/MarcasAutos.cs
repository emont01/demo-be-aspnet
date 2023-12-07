namespace api.Models;

public class MarcasAutos
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Fundacion { get; set; }
    public string Pais { get; set; }

    public override bool Equals(Object? obj)
    {
        if (obj == null) {
            return false;
        }

        if (Object.ReferenceEquals(this, obj)) {
            return true;
        }

        var other = obj as MarcasAutos;
        if (other == null) {
            return false;
        }

        return (this.Nombre == other.Nombre) &&
            (this.Fundacion == other.Fundacion) &&
            (this.Pais == other.Pais);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Nombre, this.Fundacion, this.Pais);
    }
}
