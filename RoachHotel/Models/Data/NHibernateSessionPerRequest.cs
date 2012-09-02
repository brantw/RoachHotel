﻿using System;
using System.Web;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;

namespace RoachHotel.Mvc.Models.Data
{
    /// <summary>
    /// http://www.bengtbe.com/blog/2009/10/08/nerddinner-with-fluent-nhibernate-part-3-the-infrastructure
    /// </summary>
    public class NHibernateSessionPerRequest : IHttpModule
    {
        private static readonly ISessionFactory SessionFactory;

        // Constructs our HTTP module
        static NHibernateSessionPerRequest()
        {
            SessionFactory = CreateSessionFactory();
        }

        // Initializes the HTTP module
        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
            context.EndRequest += EndRequest;
        }

        // Disposes the HTTP module
        public void Dispose() { }

        // Returns the current session
        public static ISession GetCurrentSession()
        {
            return SessionFactory.GetCurrentSession();
        }

        // Opens the session, begins the transaction, and binds the session
        private static void BeginRequest(object sender, EventArgs e)
        {
            ISession session = SessionFactory.OpenSession();

            session.BeginTransaction();

            CurrentSessionContext.Bind(session);
        }

        // Unbinds the session, commits the transaction, and closes the session
        private static void EndRequest(object sender, EventArgs e)
        {
            ISession session = CurrentSessionContext.Unbind(SessionFactory);

            if (session == null) return;

            try
            {
                session.Transaction.Commit();
            }
            catch (Exception)
            {
                session.Transaction.Rollback();
            }
            finally
            {
                session.Close();
                session.Dispose();
            }
        }

        // Returns our NHibernate session factory
        private static ISessionFactory CreateSessionFactory()
        {
            var mappings = CreateMappings();

            return Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(c => c
                        .FromConnectionStringWithKey("RoachHotel")))
                .Mappings(m => m
                    .AutoMappings.Add(mappings))
                .ExposeConfiguration(c =>
                {
                    BuildSchema(c);
                    c.Properties[NHibernate.Cfg.Environment.CurrentSessionContextClass] = "web";
                })
                .BuildSessionFactory();
        }

        // Returns our NHibernate auto mapper
        private static AutoPersistenceModel CreateMappings()
        {
            return AutoMap
                .Assembly(System.Reflection.Assembly.GetCallingAssembly())
                .Where(t => t.Namespace == "RoachHotel.Mvc.Models")
                .Conventions.Setup(c => c.Add(DefaultCascade.SaveUpdate()));
        }

        // Drops and creates the database shema
        private static void BuildSchema(Configuration cfg)
        {
            new SchemaExport(cfg)
                .Create(false, true);
        }
    }
}