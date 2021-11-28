package com.ainhoa.mypokemon

import android.annotation.SuppressLint
import android.content.ContentValues
import android.graphics.Bitmap
import android.graphics.BitmapFactory
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import androidx.fragment.app.Fragment
import com.ainhoa.mypokemon.databinding.FragmentPokedexBinding
import com.bumptech.glide.Glide
import kotlinx.coroutines.*
import java.net.URL

class PokedexFragment: Fragment() {

    private val urlImagenes = mutableListOf(
        "https://media.vandal.net/i/1200x630/10-2021/2021105724573_1.jpg"
    )

    private lateinit var binding: FragmentPokedexBinding

    private val imagenes = ArrayList<Bitmap>()


    @SuppressLint("StringFormatInvalid")
    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        Log.d(ContentValues.TAG, "onCreateView")
        binding = FragmentPokedexBinding.inflate(inflater)
        return binding.root


    }
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        Log.d(ContentValues.TAG,"onViewCreated")

        var tarea: Job? = null

        binding.button.setOnClickListener {
            if (binding.button.text == getString(R.string.btn_imageDownloader)) {
                // Se comprueba la existencia de ImageViews, si existen se eliminan.
                if (binding.myLinearLayout.childCount > 3) {
                    binding.myLinearLayout.removeViews(
                        3,
                        binding.myLinearLayout.childCount - 3
                    )
                }

                tarea = descargarImagenes()
            } else {
                tarea?.let {
                    tarea?.cancel()
                    binding.button.text = getString(R.string.btn_imageDownloader)
                    binding.tvInfo.text = getString(R.string.txt_descargaCancelada)
                }
            }
        }
    }

    private fun descargarImagenes() = GlobalScope.launch(Dispatchers.Main) {
        binding.button.text = getString(android.R.string.cancel)
        binding.tvInfo.text = getString(R.string.txt_descargando)
        binding.progressBar.progress = 0


        urlImagenes.forEach {
            Log.d("URLs", it)

            // Tarea asíncronta, se descargan las imágenes y se almacenan en un
            // ArrayList<Bitmatp>().
            withContext(Dispatchers.IO) {
                try {
                    val inputStream = URL(it).openStream()
                    imagenes.add(BitmapFactory.decodeStream(inputStream))
                } catch (e: Exception) {
                    Log.e("DOWNLOAD", e.message.toString())
                }
            }
            binding.progressBar.progress = (imagenes.size * 100) / urlImagenes.size
        }

        // Fin de la tarea.
        binding.button.text = getString(R.string.btn_imageDownloader)
        binding.tvInfo.text = getString(R.string.txt_descargaCompleta, imagenes.size)

        añadirImagenes()

    }



    // Añade las imágenes que haya dado tiempo a descargar
    private fun añadirImagenes() {
        // Se añaden las imágenes a la vista una vez descargadas.
        imagenes.forEach {
            addImagen(it)
        }

        // Limpiamos la lista de imagenes para que se quede a 0
        imagenes.clear()
    }

    fun addImagen(image: Bitmap) {
        val img = ImageView(requireContext())

// Se carga la imagen en el ImageView mediante Glide y se ajusta el tamaño.
        Glide.with(this)
            .load(image)
            .override(binding.myLinearLayout.width - 100)
            .into(img)
        img.setPadding(0, 0, 0, 10)

        // Se infla el LinearLayout con una imagen nueva.
        binding.myLinearLayout.addView(img)
    }

}