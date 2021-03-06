﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gridTest.aspx.cs" Inherits="vueTest.gridTest" %>

<!DOCTYPE html>

<html lang="en">
  <head>
    <meta charset="utf-8">
    <title>Vue.js grid component example</title>
    <%--<link rel="stylesheet" href="style.css">--%>
    <link href="CSS/style.css" rel="stylesheet" />
    <%--<script src="../../dist/vue.js"></script>--%>
    <script src="scripts/vue.js"></script>
    </head>
  <body>

    <!-- component template -->
    <script type="text/x-template" id="grid-template">
      <table>
        <thead>
          <tr>
            <th v-for="key in columns"
              @click="sortBy(key)"
              :class="{ active: sortKey == key }">
              {{ key | capitalize }}
              <span class="arrow" :class="sortOrders[key] > 0 ? 'asc' : 'dsc'">
              </span>
            </th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="entry in filteredData">
            <td v-for="key in columns">
              {{entry[key]}}
            </td>
          </tr>
        </tbody>
      </table>
    </script>

    <!-- demo root element -->
    <div id="demo">
      <form id="search">
        Search <input name="query" v-model="searchQuery">
      </form>
      <demo-grid
        :data="gridData"
        :columns="gridColumns"
        :filter-key="searchQuery">
      </demo-grid>
    </div>

    <%--<script src="grid.js"></script>--%>
    <script src="scripts/grid.js"></script>
  </body>
</html>
