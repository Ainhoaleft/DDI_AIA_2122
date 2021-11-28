package com.ainhoa.mypokemon

import android.content.Context
import android.database.Cursor
import android.database.sqlite.SQLiteDatabase
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.cursoradapter.widget.CursorAdapter
import com.ainhoa.mypokemon.databinding.ActivityListviewBinding
import com.ainhoa.mypokemon.databinding.ItemListviewBinding

class ListviewActivity : AppCompatActivity() {
    private lateinit var binding: ActivityListviewBinding
    private val amigosDBHelper = MyDBOpenHelper(this, null)

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        binding = ActivityListviewBinding.inflate(layoutInflater)
        setContentView(binding.root)
        setTitle(R.string.bt_ver_listview)

        // Se instancia la BD en modo lectura y se crea la SELECT.
        val db: SQLiteDatabase = amigosDBHelper.readableDatabase
        val cursor: Cursor = db.rawQuery(
            "SELECT * FROM ${MyDBOpenHelper.TABLA_POKEDEX};",
            null
        )
        // Se crea el CursorAdapter.
        val myCursorAdapter = MyListCursorAdapter(this, cursor)
        // Se carga los datos en el ListView.
        binding.myListview.adapter = myCursorAdapter
        db.close()
    }

    inner class MyListCursorAdapter(context: Context, cursor: Cursor) :
        CursorAdapter(context, cursor, FLAG_REGISTER_CONTENT_OBSERVER) {
        /**
         * "Infla" cada uno de los elementos de la lista.
         */
        override fun newView(
            context: Context?,
            cursor: Cursor?,
            parent: ViewGroup?
        ): View {
            val inflater = LayoutInflater.from(context)
            return inflater.inflate(R.layout.item_listview, parent, false)
        }

        /**
         * Rellena el ListView.
         */
        override fun bindView(view: View?, context: Context?, cursor: Cursor?) {
            val bindingItems = ItemListviewBinding.bind(view!!)

            with(bindingItems) {
                tvItemNombre.text = cursor!!.getString(1)
                tvItemTipo.text = cursor!!.getString(2)
                tvItemGeneracion.text = cursor!!.getString(3)
                view.setOnClickListener {
                    Toast.makeText(this@ListviewActivity,"${tvItemNombre.text} ${tvItemTipo.text} ${tvItemGeneracion.text}", Toast.LENGTH_SHORT).show()
                }
            }
        }
    }

}