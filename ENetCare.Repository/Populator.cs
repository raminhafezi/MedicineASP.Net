﻿using ENetCare.Repository.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENetCare.Repository
{
    public class Populator
    {
        public void Run(SqlConnection connection)
        {
            InsertCentreSamples(connection);
            InsertPackageTypeSamples(connection);
            InsertEmployeeSamples(connection);
            InsertPackageSamples(connection);
            InsertTransitSamples(connection);
        }

        public void InsertCentreSamples(SqlConnection connection) 
        {
            connection.Open();
            string queryFirstBit = "INSERT DistributionCentre VALUES (";
            string queryLastBit = ")";
            string[] ins = new string[12];
            ins[0] = "'Head Office', '1 Red Street, City', '0412 345 678', 1";
            ins[1] = "'North Centre', 'campsite at river bend 10 kilometers north of Elbonia', '0412 122 434', 0";
            ins[2] = "'South Centre', '5 kilometers south of Elbonia', '0212 102 144', 0";
            ins[3] = "'Cape York Centre', '12 Dusty Street, QLD 4817', '03412 345 671', 0";
            ins[4] = "'New Curvy Beach', 'North of EastVille, QLD', '0412 932 111', 0";
            ins[5] = "'Darwin Centre', '25 kilometers East of Darwin', '0412 199 124', 0";
            ins[6] = "'West Victoria Centre', '1 Red Street, VIC', '0402 405 128', 0";
            ins[7] = "'Alice Springs Centre', 'Campsite out of Alice Spring', '0212 122 434', 0";
            ins[8] = "'Waga Waga Centre', 'Waga Waga', '0512 166 344', 0";
            ins[9] = "'Spikeville Centre', '11 Red Street Spikeville, NSW', '0412 115 618', 0";
            ins[10] = "'Enet NSW Camp 3', 'South Hishire, NSW 2900', '0412 122 434', 0";
            ins[11] = "'Centre 9', ' 34 LonesomeRd ,VIC 3345', '0212 102 144', 0";
            foreach(string queryVals in ins)
            {
                string query = queryFirstBit + queryVals + queryLastBit;
                var cmd = new SqlCommand(query, connection);
                cmd.ExecuteScalar();                 
            }
            connection.Close();   
        }




        public void InsertPackageTypeSamples(SqlConnection connection)
        {
            connection.Open();
            string queryFirstBit = "INSERT StandardPackageType VALUES (";
            string queryLastBit = ")";
            string[] ins = new string[9];
            ins[0] = "'100 polio vaccinations', 100, 'MONTH', 2, 1, 100";
            ins[1] = "'500 polio vaccinations', 500, 'MONTH', 2, 1, 100";
            ins[2] = "'10L Polyheme', 10, 'MONTH', 6, 0, 50";
            ins[3] = "'200 D4 vaccinations', 200, 'MONTH', 2, 1, 100";
            ins[4] = "'box of 100 Codeine pills', 100, 'MONTH', 3, 1, 80";
            ins[5] = "'Blister of 20 Medline Plus', 20, 'MONTH', 6, 0, 50";
            ins[6] = "'100 SmallPox vaccinations', 100, 'MONTH', 2, 1, 100";
            ins[7] = "'box of 300 Amikacin pills', 300, 'MONTH', 3, 1, 80";
            ins[8] = "'200 Blisters Tobramycin', 200, 'MONTH', 6, 0, 50";
            foreach (string queryVals in ins)
            {
                string query = queryFirstBit + queryVals + queryLastBit;
                var cmd = new SqlCommand(query, connection);
                cmd.ExecuteScalar();
            }
            connection.Close();
        }



        public void InsertEmployeeSamples(SqlConnection connection)
        {
            connection.Open();
            string queryFirstBit = "INSERT Employee VALUES (";
            string queryLastBit = ")";
            string[] ins = new string[8];
            ins[0] = "'fsmith', 'password', 'Fred Smith', 'fsmith@EnetCare.com.au', 'AGENT', 1";
            ins[1] = "'jbrown', 'password', 'John Brown', 'jbrown@EnetCare.com.au', 'DOCTOR', 2";
            ins[2] = "'sbrown', 'password', 'Sam Brown', 'sbrown@EnetCare.com.au', 'DOCTOR', 3";
            ins[3] = "'hrogers', 'password', 'Harry Rogers', 'hrogers@EnetCare.com.au', 'MANAGER', 4";
            ins[4] = "'ben',   'password', 'Ben',   'Ben@EnetCare.com.au',   'AGENT', 11";
            ins[5] = "'ramin', 'password', 'Ramin', 'Ramin@EnetCare.com.au', 'AGENT', 12";
            ins[6] = "'ihab',  'password', 'Ihab',  'Ihab@EnetCare.com.au',  'AGENT', 13";
            ins[7] = "'pablo', 'password', 'Pablo', 'Pablo@EnetCare.com.au', 'AGENT', 14";
            foreach (string queryVals in ins)
            {
                string query = queryFirstBit + queryVals + queryLastBit;
                var cmd = new SqlCommand(query, connection);
                cmd.ExecuteScalar();
            }
            connection.Close();
        }



        public void InsertPackageSamples(SqlConnection connection)
        {
            connection.Open();
            string queryFirstBit = "INSERT Package VALUES (";
            string queryLastBit = ")";
            string[] ins = new string[7];
            ins[0] = "'012365423', '2015/5/20', 1, 1, 'INSTOCK', NULL";
            ins[1] = "'092312332', '2015/4/12', 1, NULL, 'INTRANSIT', NULL";
            ins[2] = "'086312442', '2015/6/05', 1, 2, 'DISTRIBUTED', 2";
            ins[3] = "'076315662', '2015/9/12', 2, 1, 'INSTOCK', NULL";
            ins[4] = "'075518862', '2015/10/5', 2, NULL, 'INTRANSIT', NULL";
            ins[5] = "'074445689', '2015/9/22', 2, 2, 'DISTRIBUTED', 2";
            ins[6] = "'073243688', '2015/8/22', 2, 2, 'LOST', 2";
            foreach (string queryVals in ins)
            {
                string query = queryFirstBit + queryVals + queryLastBit;
                var cmd = new SqlCommand(query, connection);
                cmd.ExecuteScalar();
            }
            connection.Close();
        }




        public void InsertTransitSamples(SqlConnection connection)
        {
            connection.Open();
            string queryFirstBit = "INSERT PackageTransit VALUES (";
            string queryLastBit = ")";
            string[] ins = new string[4];
            ins[0] = "2, 1, 2, '2015/2/28', NULL, NULL";
            ins[1] = "3, 1, 2, '2015/2/28', '2015/3/1', NULL";
            ins[2] = "5, 1, 3, '2015/2/28', NULL, NULL";
            ins[3] = "6, 1, 2, '2015/2/28', '2015/3/1', NULL";
            foreach (string queryVals in ins)
            {
                string query = queryFirstBit + queryVals + queryLastBit;
                var cmd = new SqlCommand(query, connection);
                cmd.ExecuteScalar();
            }
            connection.Close();
        }





    }
}