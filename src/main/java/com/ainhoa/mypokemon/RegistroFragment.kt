package com.ainhoa.mypokemon

import android.annotation.SuppressLint
import android.content.ContentValues
import android.content.Context
import android.content.Intent
import android.database.Cursor
import android.database.sqlite.SQLiteDatabase
import android.net.Uri
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.constraintlayout.widget.ConstraintLayout
import androidx.cursoradapter.widget.CursorAdapter
import androidx.fragment.app.Fragment
import com.ainhoa.mypokemon.databinding.ActivityListviewBinding
import com.ainhoa.mypokemon.databinding.FragmentPokedexBinding
import com.ainhoa.mypokemon.databinding.FragmentRegistroBinding
import com.ainhoa.mypokemon.databinding.ItemListviewBinding

class RegistroFragment : Fragment() {

    private lateinit var binding: FragmentRegistroBinding

    @SuppressLint("StringFormatInvalid")
    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        Log.d(ContentValues.TAG, "onCreateView")
        binding = FragmentRegistroBinding.inflate(inflater)
        return binding.root


    }
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        Log.d(ContentValues.TAG, "onViewCreated")


        with(binding) {

            // Abrir una página web.
            binding.btnInternet.setOnClickListener {
                val intent = Intent(
                    Intent.ACTION_VIEW,
                    Uri.parse("https://www.pokexperto.net/index2.php?seccion=nds/nationaldex/buscar")
                )

                val packageManager = null
                if (packageManager?.let { it1 -> intent.resolveActivity(it1) } != null) {
                    startActivity(intent)
                } else {
                    Log.d("DEBUG", "Hay un problema para encontrar un navegador.")
                }
            }

        }
    }
}
