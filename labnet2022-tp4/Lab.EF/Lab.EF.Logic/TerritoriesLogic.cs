using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class TerritoriesLogic : BaseLogic<Territories, string>     
    {
     
            public override List<Territories> GetAll()
            {
                return context.Territories.ToList();
            }

        public override bool Agregar(Territories entity)
        {
            try
            {
                context.Territories.Add(entity);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public override Territories GetById(string id)
        {
            return context.Territories.Find(id);
        }

        public override bool Eliminar(string id)
        {
            //var territorioAEliminar = context.GetById(id);
            
                var territorioAEliminar = context.Territories.FirstOrDefault(r => r.TerritoryID == id);
                if (territorioAEliminar != null)
                {
                    context.Territories.Remove(territorioAEliminar);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
        }

        public override string Modificar(string idViejo, Territories territories)
        {
            var territorioUpdate = context.Territories.FirstOrDefault(r => r.TerritoryID == idViejo);
            //no se por que no puedo modificar el ID de la tabla
            if (territorioUpdate != null)
            {
                
                try
                {
                    //territorioUpdate.TerritoryID = territories.TerritoryID;
                    territorioUpdate.TerritoryDescription = territories.TerritoryDescription;
                    territorioUpdate.RegionID = territories.RegionID;
                    context.SaveChanges();
                    return "exito";
                }
                catch(Exception ex)
                {
                    return "errorDato";
                }
                
                
            }
            else
            {
                return "errorNulo";
            }
        }
    }
}
