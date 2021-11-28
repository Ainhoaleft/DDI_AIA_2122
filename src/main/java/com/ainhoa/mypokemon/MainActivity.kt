package com.ainhoa.mypokemon

import android.content.Intent
import android.database.Cursor
import android.database.sqlite.SQLiteDatabase
import android.net.Uri
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.Toast
import androidx.appcompat.app.ActionBarDrawerToggle
import androidx.appcompat.app.AlertDialog
import androidx.fragment.app.Fragment
import com.ainhoa.mypokemon.databinding.ActivityMainBinding
import com.ainhoa.mypokemon.databinding.DialogoBinding

const val UPDATE = "update"
const val DELETE = "delete"

class MainActivity : AppCompatActivity() {
    private lateinit var binding: ActivityMainBinding
    private lateinit var amigosDBHelper: MyDBOpenHelper

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        // Se instancia el objeto MyDBOpenHelper.
        amigosDBHelper = MyDBOpenHelper(this, null)


        with(binding) {

            // Abrir una página web.
             binding.btnInternet.setOnClickListener {
                 val intent = Intent(
                 Intent.ACTION_VIEW,
                 Uri.parse("https://www.pokexperto.net/index2.php?seccion=nds/nationaldex/buscar")
                 )

                 if (intent.resolveActivity(packageManager) != null) {
                 startActivity(intent)
                 } else {
                 Log.d("DEBUG", "Hay un problema para encontrar un navegador.")
                 }
                 }

            // Botón INSERTAR.
            btnInsertar.setOnClickListener {
                if (etGeneracion.text.isNotBlank() && etNombre.text.isNotBlank() && etTipo.text.isNotBlank()) {
                    // Se inserta en la tabla.
                    amigosDBHelper.addpokemon(
                        etGeneracion.text.toString(),
                        etNombre.text.toString(),
                        etTipo.text.toString()
                    )
                    // Se limpian los EditText después de la inserción.
                    etGeneracion.text.clear()
                    etNombre.text.clear()
                    etTipo.text.clear()
                } else {
                    myToast("Los campos no pueden estar vacíos.")
                }
            }

            // Botón ACTUALIZAR.
            btnActualizar.setOnClickListener {
                if (etGeneracion.text.isNotBlank() && etNombre.text.isNotBlank() && etTipo.text.isNotBlank()) {
                    // Se lanza el dialogo para solicitar el id del registro,
                    // además, se indica el tipo de operación.
                    solicitaIdentificador(UPDATE)
                } else {
                    myToast("El campo nombre no debe estar vacío.")
                }
            }

            // Botón ELIMINAR.
            btnEliminar.setOnClickListener {
                // Se lanza el dialogo para solicitar el id del registro,
                // además, se indica el tipo de operación.
                solicitaIdentificador(DELETE)
            }

            // Botón CONSULTAR.
            btnConsultar.setOnClickListener {
                tvResult.text = ""

                // Se instancia la BD en modo lectura y se crea la SELECT.
                val db: SQLiteDatabase = amigosDBHelper.readableDatabase
                val cursor: Cursor = db.rawQuery(
                    "SELECT * FROM ${MyDBOpenHelper.TABLA_POKEDEX};",
                    null
                )

                // Se comprueba que al menos exista un registro.
                if (cursor.moveToFirst()) {
                    do {
                        tvResult.append(cursor.getInt(0).toString() + " - ")
                        tvResult.append(cursor.getString(1).toString() + " ")
                        tvResult.append(cursor.getString(2).toString() + " ")
                        tvResult.append(cursor.getString(3).toString() + "\n")
                    } while (cursor.moveToNext())
                } else {
                    myToast("No existen datos a mostrar.")
                }
                db.close()
            }

            // Botón VER EN LISTVIEW.
            btnVerListview.setOnClickListener {
                val myIntent = Intent(this@MainActivity, SecondActivity::class.java)
                startActivity(myIntent)
            }


            // Botón VER EN RECYCLERVIEW.
            btnVerRecyclerview.setOnClickListener {
                val myIntent = Intent(this@MainActivity, RecyclerviewActivity::class.java)
                startActivity(myIntent)
            }

        }

    }


    /**
     * Método encargado de mostrar un cuadro de diálogo para pedir el
     * identificador al usuario y realizar la acción correspondiente según
     * la acción requerida.
     */


    fun solicitaIdentificador(accion: String) {
        val builder = AlertDialog.Builder(this@MainActivity)
        builder.apply {
            // Utilizamos ViewBinding en vez de Synthetic Binding
            var bindingDialogo: DialogoBinding

            bindingDialogo = DialogoBinding.inflate(layoutInflater)
            setView(bindingDialogo.root)
            /*val inflater = layoutInflater
            setView(inflater.inflate(R.layout.dialogo, null))*/

            setPositiveButton(android.R.string.ok) { dialog, _ ->
                //val valor = (dialog as AlertDialog).identificador.text
                val valor = bindingDialogo.identificador.text
                val identificador = valor.toString().toInt()

                // Se realiza la acción.
                when (accion) {
                    UPDATE -> {
                        val nombre = binding.etNombre.text.toString()
                        amigosDBHelper.editarPokemon(identificador, nombre)

                        // Se limpian los EditText después de la inserción.
                        binding.etGeneracion.text.clear()
                        binding.etNombre.text.clear()
                        binding.etTipo.text.clear()
                    }
                    DELETE -> {
                        myToast(
                            "Eliminado/s " + "${amigosDBHelper.eliminarpokemon(identificador)} " +
                                    "registro/s"
                        )

                    }
                }
            }
            setNegativeButton(android.R.string.no) { dialog, _ ->
                dialog.dismiss()
            }
        }.show()
    }

    fun myToast(mensaje: String) {
        Toast.makeText(this@MainActivity, mensaje, Toast.LENGTH_SHORT).show()
    }



}