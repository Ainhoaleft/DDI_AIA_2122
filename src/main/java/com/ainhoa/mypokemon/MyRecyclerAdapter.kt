package com.ainhoa.mypokemon

import android.content.Context
import android.database.Cursor
import android.util.Log
import android.view.*
import android.widget.TextView
import android.widget.Toast
import androidx.recyclerview.widget.RecyclerView
import com.ainhoa.mypokemon.databinding.ItemRecyclerviewBinding

class MyRecyclerViewAdapter
    : RecyclerView.Adapter<MyRecyclerViewAdapter.ViewHolder>() {

    private lateinit var context: Context
    private lateinit var cursor: Cursor
    private var actionMode: ActionMode? = null

    fun MyRecyclerViewAdapter(context: Context, cursor: Cursor) {
        this.context = context
        this.cursor = cursor
    }


    /**
     * Se "infla" la vista de los items.
     */
    override fun onCreateViewHolder(
        parent: ViewGroup,
        viewType: Int
    ): ViewHolder {
        Log.d("RECYCLERVIEW", "onCreateViewHolder")
        val inflater = LayoutInflater.from(parent.context)
        return ViewHolder(
            inflater.inflate(
                R.layout.item_recyclerview,
                parent,
                false
            )
        )
    }

    override fun getItemCount(): Int {
        return if (cursor != null)
            cursor.count
        else 0
    }


    /**
     * Se completan los datos de cada vista mediante ViewHolder.
     */
    override fun onBindViewHolder(
        holder: MyRecyclerViewAdapter.ViewHolder,
        position: Int
    ) {
        // Importante para recorrer el cursor.
        cursor.moveToPosition(position)
        Log.d("RECYCLERVIEW", "onBindViewHolder")
        // Se asignan los valores a los elementos de la UI.
        holder.id.text = cursor.getString(0)
        holder.generacion.text = cursor.getString(1)
        holder.nombre.text = cursor.getString(2)
        holder.tipo.text = cursor.getString(3)
    }

    inner class ViewHolder : RecyclerView.ViewHolder {
        // Creamos las referencias de la UI.
        val id: TextView
        val generacion: TextView
        val nombre: TextView
        val tipo: TextView

        constructor(view: View) : super(view) {

            // Se enlazan los elementos de la UI mediante ViewBinding.
            val bindingItemsRV = ItemRecyclerviewBinding.bind(view)
            this.id = bindingItemsRV.tvIdentificador
            this.generacion = bindingItemsRV.tvGeneracion
            this.nombre = bindingItemsRV.tvNombre
            this.tipo = bindingItemsRV.tvTipo

            view.setOnClickListener {
                Toast.makeText(
                    context,
                    "${this.id.text}-${this.generacion.text} ${this.nombre.text} ${this.tipo.text}",
                    Toast.LENGTH_SHORT
                ).show()
            }

            view.setOnLongClickListener {
                when (actionMode) {
                    null -> {
                        // Se lanza el ActionMode.
                        actionMode = it.startActionMode(actionModeCallback)
                        it.isSelected = true
                        true
                    }
                    else -> false
                }

                return@setOnLongClickListener true
            }

        }

        /**
         * Modo de acción contextual.
         */
        private val actionModeCallback = object : ActionMode.Callback {
            // Método llamado al selección una opción del menú.
            override fun onActionItemClicked(mode: ActionMode?, item: MenuItem?)
                    : Boolean {

                return when (item!!.itemId) {
                    R.id.optionDelete -> {
                        Toast.makeText(
                            context,
                            "Eliminar el elemento: ${adapterPosition}",
                            Toast.LENGTH_LONG
                        )
                            .show()
                        mode!!.finish()
                        return true
                    }
                    R.id.optionShare -> {
                        Toast.makeText(context, R.string.menu_op_share, Toast.LENGTH_LONG)
                            .show()
                        return true
                    }
                    else -> false
                }
            }

            // Llamado cuando al crear el modo acción a través de startActionMode().
            override fun onCreateActionMode(mode: ActionMode?, menu: Menu?): Boolean {
                //val inflater = mActivity?.menuInflater
                // Así no necesito la activity
                val inflater = mode?.menuInflater
                inflater?.inflate(R.menu.action_mode_menu, menu)
                return true
            }

            // Se llama cada vez que el modo acción se muestra, siempre
            // después de onCreateActionMode().
            override fun onPrepareActionMode(mode: ActionMode?, menu: Menu?)
                    : Boolean {
                return false
            }

            // Se llama cuando el usuario sale del modo de acción.
            override fun onDestroyActionMode(mode: ActionMode?) {
                actionMode = null
            }
        }
    }
}