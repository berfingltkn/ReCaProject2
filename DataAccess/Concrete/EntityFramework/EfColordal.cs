﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColordal : IColorDal
    {
        public void Add(Color entity)
        {
            using (RentCarDBContext context=new RentCarDBContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using(RentCarDBContext context=new RentCarDBContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using(RentCarDBContext context=new RentCarDBContext()) {

                return context.Set<Color>().SingleOrDefault(filter);

            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (RentCarDBContext context = new RentCarDBContext())
            {
                return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList();
            }

        }

        public void Update(Color entity)
        {
            using(RentCarDBContext context=new RentCarDBContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
